using MediatR;

namespace Testique.API.Application.Features.Queries.User.GetUserById;

/// <summary>
/// Обработчик для <see cref="GetUserByIdQuery"/>
/// </summary>
public class GetUserByIdQueryHandler(IDbContext dbContext, IStringLocalizer<ExceptionMessages> localizer)
    : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    /// <inheritdoc />
    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new RequestException(localizer[nameof(RequestException.RequestIsEmpty)]);

        var userInfoFromDb = await dbContext.UserInfos
                                 .Include(x => x.User)
                                 .Include(x => x.Country)
                                 .FirstOrDefaultAsync(x => x.UserId == request.Id || x.Id == request.Id,
                                     cancellationToken)
                             ?? throw new UserException(localizer[nameof(UserException.UserByIdNotFound)]);

        return new GetUserByIdResponse
        {
            Id = userInfoFromDb.Id,
            UserName = userInfoFromDb.User.UserName ?? "Unknown",
            FirstName = userInfoFromDb.FirstName,
            LastName = userInfoFromDb.LastName,
            Patronymic = userInfoFromDb.Patronymic,
            CountryName = userInfoFromDb.Country.Name,
            ImageId = userInfoFromDb.ImageId
        };
    }
}