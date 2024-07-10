using MediatR;
using Microsoft.AspNetCore.Http;
using Testique.API.Application.Contracts.Test.GenerateTestLink;

namespace Testique.API.Application.Features.Queries.Test.GenerateTestLink;

/// <summary>
/// Обработчик для генерации ссылки на прохождение теста.
/// </summary>
public class GenerateTestLinkQueryHandler(IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<GenerateTestLinkQuery, GenerateTestLinkResponse>
{
    public Task<GenerateTestLinkResponse> Handle(GenerateTestLinkQuery request, CancellationToken cancellationToken)
    {
        var baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
        var testLink = $"{baseUrl}/Tests/TakeTest/{request.TestId}";

        return Task.FromResult(new GenerateTestLinkResponse { TestLink = testLink });
    }
}