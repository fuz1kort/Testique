using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Testique.API.Application.Features.Queries.Auth.PostLogin;

public class PostLoginCommandHandler(
    SignInManager<Domain.Entities.User> signInManager,
    UserManager<Domain.Entities.User> userManager,
    IStringLocalizer<ExceptionMessages> localizer)
    : IRequestHandler<PostLoginCommand, PostLoginResponse>
{
    /// <inheritdoc />
    public async Task<PostLoginResponse> Handle(PostLoginCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new RequestException(localizer[nameof(RequestException.RequestIsEmpty)]);

        var user = await userManager.FindByNameAsync(request.Username);

        if (user == null)
            throw new UserException(localizer[nameof(UserException.UserByUserNameNotFound)]);

        var isEmailConfirmed = await userManager.IsEmailConfirmedAsync(user);

        if (!isEmailConfirmed)
            throw new UserException(localizer[nameof(UserException.EmailNotConfirmed)]);

        var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);

        if (!result.Succeeded)
            return new PostLoginResponse
            {
                IsSucceed = false,
                Error = localizer[nameof(UserException.LoginFailed)]
            };

        return new PostLoginResponse
        {
            IsSucceed = true,
            Error = null
        };
    }
}