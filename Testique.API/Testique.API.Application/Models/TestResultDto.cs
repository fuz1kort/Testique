namespace Testique.API.Application.Models;

/// <summary>
/// DTO для результатов теста.
/// </summary>
public class TestResultDto
{
    public Guid TestId { get; set; }
    public string TestName { get; set; } = default!;
    public TimeSpan Time { get; set; }
    public int Score { get; set; }
    public List<QuestionResultDto> QuestionResults { get; set; } = default!;
    public string UserId { get; set; } = default!;
}