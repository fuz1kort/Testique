using MediatR;
using Testique.API.Application.Contracts.Test.GetPassedTests;

namespace Testique.API.Application.Features.Queries.Test.GetPassedTests;

/// <summary>
/// Запрос на получение пройденных тестов и их результатов.
/// </summary>
public class GetPassedTestsQuery : IRequest<GetPassedTestsResponse>
{
}