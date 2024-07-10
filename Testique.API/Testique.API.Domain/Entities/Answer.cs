using Testique.API.Domain.Common;

namespace Testique.API.Domain.Entities;

/// <summary>
/// Представляет ответ на вопрос.
/// </summary>
public class Answer: BaseEntity
{
    /// <summary>
    /// Текст ответа.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Определяет, является ли ответ правильным.
    /// </summary>
    public bool IsCorrect { get; set; }
    
    public Guid QuestionId { get; set; }

    public Question Question { get; set; } = default!;
}