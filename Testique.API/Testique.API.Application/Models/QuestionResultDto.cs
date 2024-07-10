namespace Testique.API.Application.Models;

/// <summary>
/// DTO для результатов вопросов.
/// </summary>
public class QuestionResultDto
{
    public Guid QuestionId { get; set; }
    public string QuestionContent { get; set; } = default!;
    public Guid SelectedAnswerId { get; set; }
    public bool IsCorrect { get; set; }
}