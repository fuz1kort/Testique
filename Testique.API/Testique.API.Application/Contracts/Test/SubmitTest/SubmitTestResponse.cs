using Testique.API.Application.Models;

namespace Testique.API.Application.Contracts.Test.SubmitTest;

public class SubmitTestResponse
{
    public TestResultDto TestResult { get; set; } = default!;
}