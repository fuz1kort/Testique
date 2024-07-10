namespace Testique.API.Application.Models;

/// <summary>
/// DTO для вопроса.
/// </summary>
public class QuestionDto
{
    /// <summary>
    /// Содержание вопроса.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Список ответов для вопроса.
    /// </summary>
    public List<AnswerDto> Answers { get; set; } = default!;
}