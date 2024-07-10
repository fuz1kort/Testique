using Microsoft.AspNetCore.Identity;
using Testique.API.Domain.Common;

namespace Testique.API.Domain.Entities;

/// <summary>
/// Представляет результат прохождения теста.
/// </summary>
public class TestResult : BaseAuditableEntity
{
    /// <summary>
    /// Название теста, который был пройден.
    /// </summary>
    public string TestName { get; set; } = default!;

    /// <summary>
    /// Список результатов по каждому вопросу теста.
    /// </summary>
    public List<QuestionResult> QuestionResults { get; set; } = default!;

    /// <summary>
    /// Итоговый балл за пройденный тест.
    /// </summary>
    public Guid Score { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя, прошедшего тест.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Пользователь, прошедший тест.
    /// </summary>
    public IdentityUser User { get; set; } = default!;
}