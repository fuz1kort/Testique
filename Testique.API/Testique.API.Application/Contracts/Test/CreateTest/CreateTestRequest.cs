using Testique.API.Application.Models;

namespace Testique.API.Application.Contracts.Test.CreateTest;

/// <summary>
/// Модель запроса на создание нового теста.
/// </summary>
public class CreateTestRequest
{
    /// <summary>
    /// Название теста.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// ID создателя теста.
    /// </summary>
    public int CreatorId { get; set; }

    /// <summary>
    /// Список вопросов для теста.
    /// </summary>
    public List<QuestionDto> Questions { get; set; } = default!;
}