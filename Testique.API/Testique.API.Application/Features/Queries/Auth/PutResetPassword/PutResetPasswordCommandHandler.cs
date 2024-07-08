using System.Net;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Testique.API.Application.Features.Queries.Auth.PutResetPassword;

public class PutResetPasswordCommandHandler(
    UserManager<Domain.Entities.User> userManager,
    IStringLocalizer<ExceptionMessages> localizer)
    : IRequestHandler<PutResetPasswordCommand, PutResetPasswordResponse>
{
    public async Task<PutResetPasswordResponse> Handle(PutResetPasswordCommand request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new RequestException(localizer[nameof(RequestException.RequestIsEmpty)]);

        if (!Guid.TryParse(request.UserId, out _))
            throw new RequestException(localizer[nameof(RequestException.RequestHaveBadId)]);

        var user = await userManager.FindByIdAsync(request.UserId);

        if (user == null)
            throw new UserException(localizer[nameof(UserException.UserByIdNotFound)]);

        var decodedToken = WebUtility.HtmlDecode(request.Token);

        var result = await userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);

        if (!result.Succeeded)
            return new PutResetPasswordResponse
            {
                IsSucceed = false,
                Error = localizer[nameof(UserException.ResetPasswordFailed)]
            };

        return new PutResetPasswordResponse
        {
            IsSucceed = true,
            Error = null
        };
    }
}