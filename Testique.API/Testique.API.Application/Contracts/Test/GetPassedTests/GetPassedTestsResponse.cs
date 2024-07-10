using Testique.API.Application.Models;

namespace Testique.API.Application.Contracts.Test.GetPassedTests;

/// <summary>
/// Ответ с пройденными тестами и их результатами.
/// </summary>
public class GetPassedTestsResponse
{
    public List<TestResultDto> TestResults { get; set; } = default!;
}