using Testique.API.Domain.Common;

namespace Testique.API.Domain.Entities;

/// <summary>
/// Представляет вопрос, содержащий ответы.
/// </summary>
public class Question : BaseEntity
{
    /// <summary>
    /// Текст вопроса.
    /// </summary>
    public string Content { get; set; } = default!;

    /// <summary>
    /// Список ответов на данный вопрос.
    /// </summary>
    public List<Answer> Answers { get; set; } = default!;
}