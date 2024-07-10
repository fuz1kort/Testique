using Microsoft.AspNetCore.Identity;
using Testique.API.Domain.Common;

namespace Testique.API.Domain.Entities;

/// <summary>
/// Представляет тест, содержащий вопросы.
/// </summary>
public class Test : BaseAuditableEntity
{
    /// <summary>
    /// Название теста.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Список вопросов, содержащихся в тесте.
    /// </summary>
    public List<Question> Questions { get; set; } = default!;

    /// <summary>
    /// Создатель теста.
    /// </summary>
    public IdentityUser Creator { get; set; } = default!;
}