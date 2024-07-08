using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Testique.API.Application.Features.Queries.User.GetUser;

/// <summary>
/// Обработчик для <see cref="GetUserQuery"/>
/// </summary>
public class GetUserQueryHandler(
    UserManager<Domain.Entities.User> userManager,
    IUserContext userContext,
    IDbContext dbContext,
    IStringLocalizer<ExceptionMessages> localizer)
    : IRequestHandler<GetUserQuery, GetUserResponse>
{
    /// <inheritdoc cref="IRequestHandler{TRequest,TResponse}"/>
    public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var userId = userContext.CurrentUserId;

        if (userId is null)
            throw new UserException(localizer[nameof(UserException.PermissionDenied)]);

        var user = await userManager.FindByIdAsync(userId.ToString()!);

        if (user is null)
            throw new UserException(localizer[nameof(UserException.UserByIdNotFound)]);

        var roles = (await userManager.GetRolesAsync(user)).ToList();

        var userInfo = await dbContext.UserInfos
            .Include(u => u.Image)
            .Where(u => u.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);

        if (userInfo == null)
            throw new UserException(localizer[nameof(UserException.UserInfoNotFound)]);

        return new GetUserResponse
        {
            UserId = user.Id,
            Email = user.Email!,
            UserName = user.UserName!,
            Roles = roles,
            UserInfoId = userInfo.Id,
            UserPhotoId = userInfo.ImageId
        };
    }
}