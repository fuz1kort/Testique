using System.Net;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Testique.API.Application.Contracts.Auth.GetConfirmEmail;

namespace Testique.API.Application.Features.Queries.Auth.GetConfirmEmail;

public class GetConfirmEmailQueryHandler(UserManager<IdentityUser> userManager)
    : IRequestHandler<GetConfirmEmailQuery, GetConfirmEmailResponse>
{
    public async Task<GetConfirmEmailResponse> Handle(GetConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();
        
        if (!Guid.TryParse(request.UserId, out _))
            throw new Exception();
        
        var user = await userManager.FindByIdAsync(request.UserId);

        if (user == null)
            throw new Exception();

        if (user.EmailConfirmed)
            throw new Exception();

        var decodedToken = WebUtility.HtmlDecode(request.Token);

        var result = await userManager.ConfirmEmailAsync(user, decodedToken);

        if (!result.Succeeded)
            return new GetConfirmEmailResponse
            {
                IsSucceed = false,
                Error = "Error"
            };

        return new GetConfirmEmailResponse
        {
            IsSucceed = true,
            Error = null
        };
    }
}