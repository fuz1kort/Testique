using MediatR;
using Testique.API.Application.Contracts.Test.GetTestParticipants;

namespace Testique.API.Application.Features.Queries.Test.GetTestParticipants;

public class GetTestParticipantsQuery : IRequest<GetTestParticipantsResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">ИД теста</param>
    public GetTestParticipantsQuery(Guid id)
        => Id = id;

    /// <summary>
    /// ИД теста
    /// </summary>
    public Guid Id { get; set; }
}