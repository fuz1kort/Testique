using System.Net;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Testique.API.Application.Contracts.Auth.PutResetPassword;

namespace Testique.API.Application.Features.Queries.Auth.PutResetPassword;

public class PutResetPasswordCommandHandler(
    UserManager<IdentityUser> userManager)
    : IRequestHandler<PutResetPasswordCommand, PutResetPasswordResponse>
{
    public async Task<PutResetPasswordResponse> Handle(PutResetPasswordCommand request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        if (!Guid.TryParse(request.UserId, out _))
            throw new Exception();

        var user = await userManager.FindByIdAsync(request.UserId);

        if (user == null)
            throw new Exception();

        var decodedToken = WebUtility.HtmlDecode(request.Token);

        var result = await userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);

        if (!result.Succeeded)
            return new PutResetPasswordResponse
            {
                IsSucceed = false,
                Error = "Error"
            };

        return new PutResetPasswordResponse
        {
            IsSucceed = true,
            Error = null
        };
    }
}