using MediatR;

namespace Testique.API.Application.Features.Queries.User.GetLeaderboard;

public class GetLeaderboardQueryHandler(IDbContext dbContext, IStringLocalizer<ExceptionMessages> localizer)
    : IRequestHandler<GetLeaderboardQuery, GetLeaderboardResponse>
{
    public async Task<GetLeaderboardResponse> Handle(GetLeaderboardQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new RequestException(localizer[nameof(RequestException.RequestIsEmpty)]);

        var query = dbContext.Users
            .Include(u => u.Wallet)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.Filter))
            query = query.Where(u => !string.IsNullOrWhiteSpace(u.UserName) && u.UserName.Contains(request.Filter));

        var users = query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var responseItems = await users.Select(u => new GetLeaderboardItem
        {
            UserId = u.Id,
            Username = u.UserName ?? "Unknown",
            Balance = u.Wallet.Balance
        }).ToListAsync(cancellationToken);
        
        return new GetLeaderboardResponse { Users = responseItems };
    }
}