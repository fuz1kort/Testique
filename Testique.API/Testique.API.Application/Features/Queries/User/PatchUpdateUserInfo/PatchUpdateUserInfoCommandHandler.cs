using MediatR;

namespace Testique.API.Application.Features.Queries.User.PatchUpdateUserInfo;

public class PatchUpdateUserInfoCommandHandler(IDbContext dbContext, IUserContext userContext, IStringLocalizer<ExceptionMessages> localizer)
    : IRequestHandler<PatchUpdateUserInfoCommand, bool>
{
    /// <inheritdoc />
    public async Task<bool> Handle(PatchUpdateUserInfoCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new RequestException(localizer[nameof(RequestException.RequestIsEmpty)]);

        if (userContext.CurrentUserId == null)
            throw new UserException(localizer[nameof(UserException.PermissionDenied)]);

        Console.WriteLine(localizer[nameof(RequestException.RequestHaveBadId)].Value);
        
        if(request.CountryId is not null && !Guid.TryParse(request.CountryId, out _))
            throw new RequestException(localizer[nameof(RequestException.RequestHaveBadId)].Value);
        
        var userFromDb = await dbContext.Users
                             .Include(x => x.UserInfo)
                             .FirstOrDefaultAsync(x => x.Id == userContext.CurrentUserId, cancellationToken)
                         ??   throw new UserException(localizer[nameof(UserException.UserByIdNotFound)]);

        if (userFromDb.UserInfo is null)
            throw new UserException(localizer[nameof(UserException.UserByIdNotFound)]);

        var updatedUserInfo = new UserInfo
        {
            FirstName = request.FirstName ?? userFromDb.UserInfo.FirstName,
            LastName = request.LastName ?? userFromDb.UserInfo.LastName,
            Patronymic = request.Patronymic ?? userFromDb.UserInfo.Patronymic,
            CountryId = request.CountryId != null ? Guid.Parse(request.CountryId) : userFromDb.UserInfo.CountryId,
            ImageId = request.ImageId != null ? Guid.Parse(request.ImageId) : userFromDb.UserInfo.ImageId
        };

        userFromDb.UserName = request.Username ?? userFromDb.UserName;

        if (userFromDb.UserInfo is null)
            throw new Exception(nameof(userFromDb.UserInfo));

        userFromDb.UserInfo.UpdateInfo(updatedUserInfo);
        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}