using MediatR;
using Testique.API.Application.Contracts.Test.GenerateTestLink;

namespace Testique.API.Application.Features.Queries.Test.GenerateTestLink;

/// <summary>
/// Запрос на генерацию ссылки для прохождения теста.
/// </summary>
public class GenerateTestLinkQuery : IRequest<GenerateTestLinkResponse>
{
    public Guid TestId { get; set; }

    public GenerateTestLinkQuery(Guid testId)
        => TestId = testId;
}