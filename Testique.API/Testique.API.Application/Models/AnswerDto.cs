namespace Testique.API.Application.Models;

/// <summary>
/// DTO для ответа.
/// </summary>
public class AnswerDto
{
    /// <summary>
    /// Содержание ответа.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Является ли ответ правильным.
    /// </summary>
    public bool IsCorrect { get; set; }
}