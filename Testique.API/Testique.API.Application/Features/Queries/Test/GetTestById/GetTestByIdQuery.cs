using MediatR;
using Testique.API.Application.Contracts.Test.GetTestById;

namespace Testique.API.Application.Features.Queries.Test.GetTestById;

/// <summary>
/// Запрос на получения пользователя
/// </summary>
public class GetTestByIdQuery : IRequest<GetTestByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">ИД пользователя</param>
    public GetTestByIdQuery(Guid id)
        => Id = id;

    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid Id { get; set; }
}