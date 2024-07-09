using System.Globalization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Testique.API.Application.Contracts.User.GetUser;
using Testique.API.Application.Contracts.User.GetUserById;
using Testique.API.Application.Features.Queries.User.GetUser;
using Testique.API.Application.Features.Queries.User.GetUserById;

namespace Testique.API.WEB.Controllers;

/// <summary>
/// Контроллер отвечающий за действия с аккаунтом
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mediator">Медиатор из библиотеки MediatR</param>
    public UserController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Запрос текущего пользователя
    /// </summary>
    /// <returns>GetUserResponse(Id, Email, UserName, Roles, UserPhotoId)</returns>
    [HttpGet("GetUser")]
    public async Task<GetUserResponse> GetUser(CancellationToken cancellationToken)
        => await _mediator.Send(new GetUserQuery(), cancellationToken);

    /// <summary>
    /// Запрос пользователя по ИД
    /// </summary>
    /// <returns>GetUserResponse(Id, UserName, FirstName, LastName, Patronymic, CountryId)</returns>
    [AllowAnonymous]
    [HttpGet("GetUserInfoById/{id:guid}")]
    public async Task<GetUserByIdResponse> GetUserInfoById(string id, CancellationToken cancellationToken)
        => await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
}