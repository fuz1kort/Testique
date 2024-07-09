using MediatR;
using Testique.API.Application.Contracts.User.GetUserById;

namespace Testique.API.Application.Features.Queries.User.GetUserById;

/// <summary>
/// Запрос на получения пользователя
/// </summary>
public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">ИД пользователя</param>
    public GetUserByIdQuery(string id)
        => Id = id;

    /// <summary>
    /// ИД пользователя
    /// </summary>
    public string? Id { get; set; }
}