using Testique.API.Domain.Common;

namespace Testique.API.Domain.Entities;

/// <summary>
/// Представляет результат ответа на конкретный вопрос.
/// </summary>
public class QuestionResult : BaseEntity
{
    public Guid TestResultId { get; set; }
    public Guid QuestionId { get; set; }
    
    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string QuestionContent { get; set; } = default!;

    /// <summary>
    /// Идентификатор выбранного ответа.
    /// </summary>
    public Guid SelectedAnswerId { get; set; }

    /// <summary>
    /// Определяет, является ли выбранный ответ правильным.
    /// </summary>
    public bool IsCorrect { get; set; }
}