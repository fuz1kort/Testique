using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Testique.API.Application.Contracts.Auth.PostLogin;

namespace Testique.API.Application.Features.Queries.Auth.PostLogin;

public class PostLoginCommandHandler(
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager)
    : IRequestHandler<PostLoginCommand, PostLoginResponse>
{
    /// <inheritdoc />
    public async Task<PostLoginResponse> Handle(PostLoginCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        var user = await userManager.FindByNameAsync(request.Username);

        if (user == null)
            throw new Exception();

        var isEmailConfirmed = await userManager.IsEmailConfirmedAsync(user);

        if (!isEmailConfirmed)
            throw new Exception();

        var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);

        if (!result.Succeeded)
            return new PostLoginResponse
            {
                IsSucceed = false,
                Error = "Error"
            };

        return new PostLoginResponse
        {
            IsSucceed = true,
            Error = null
        };
    }
}