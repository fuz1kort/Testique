using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using HttpContextException = GamFi.API.Application.Exceptions.HttpContextException;

namespace Testique.API.Application.Features.Queries.Auth.PostRegister;

/// <summary>
/// Обработчик для <see cref="PostRegisterCommand"/>
/// </summary>
public class PostRegisterCommandHandler(
    UserManager<Domain.Entities.User> userManager,
    IDbContext dbContext,
    IEmailSender emailSender,
    IHttpContextAccessor httpContextAccessor,
    IStringLocalizer<ExceptionMessages> localizer)
    : IRequestHandler<PostRegisterCommand, Unit>
{
    /// <inheritdoc />
    public async Task<Unit> Handle(PostRegisterCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new RequestException(localizer[nameof(RequestException.RequestIsEmpty)]);

        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is not null)
            throw new UserException(localizer[nameof(UserException.UserAlreadyExists)]);

        var wallet = new Domain.Entities.Wallet();

        dbContext.Wallets.Add(wallet);

        var userInfo = new UserInfo
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Patronymic = request.Patronymic,
            CountryId = Guid.Parse(request.CountryId),
        };
        
        await dbContext.UserInfos.AddAsync(userInfo, cancellationToken);

        user = new Domain.Entities.User
        {
            UserName = request.Username,
            Email = request.Email,
            UserInfo = userInfo,
            UserInfoId = userInfo.Id,
            WalletId = wallet.Id,
            Wallet = wallet
        };

        var result = await userManager
            .CreateAsync(user, request.Password);

        if (!result.Succeeded)
            throw new UserException(localizer[nameof(UserException.RegistrationFailed)]);

        var addToRoleResult = await userManager.AddToRoleAsync(user, BaseRoles.UserRoleName.ToUpper());

        if (!addToRoleResult.Succeeded)
            throw new UserException(localizer[nameof(UserException.RoleSettingFailed)]);

        if (httpContextAccessor.HttpContext == null)
            throw new HttpContextException(localizer[nameof(HttpContextException.HttpContextIsNull)]);

        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

        var encodedToken = WebUtility.UrlEncode(token);

        var scheme = httpContextAccessor.HttpContext.Request.Scheme;
        var host = httpContextAccessor.HttpContext.Request.Host.ToUriComponent();

        var confirmationLink = $"{scheme}://{host}/api/Auth/ConfirmEmail?userId={user.Id}&token={encodedToken}";

        await emailSender.SendEmailAsync(user.Email, "Подтверждение регистрации",
            $"Для завершения регистрации перейдите по ссылке: {confirmationLink}");

        return Unit.Value;
    }
}