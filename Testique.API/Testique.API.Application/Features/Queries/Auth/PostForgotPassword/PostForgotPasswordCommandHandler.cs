using System.Net;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Testique.API.Application.Models;

namespace Testique.API.Application.Features.Queries.Auth.PostForgotPassword;

public class PostForgotPasswordCommandHandler(
    UserManager<IdentityUser> userManager,
    IEmailSender emailSender,
    FrontendSettings frontendSettings)
    : IRequestHandler<PostForgotPasswordCommand, Unit>
{
    /// <inheritdoc />
    public async Task<Unit> Handle(PostForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new Exception();

        if (!user.EmailConfirmed)
            throw new Exception();

        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        var encodedToken = WebUtility.UrlEncode(token);

        var resetPasswordLink = $"{frontendSettings.BaseUrl}/reset-password?userId={user.Id}&token={encodedToken}";

        await emailSender.SendEmailAsync(user.Email!, "Смена пароля",
            $"Для смены пароля перейдите по ссылке: {resetPasswordLink}");

        return Unit.Value;
    }
}