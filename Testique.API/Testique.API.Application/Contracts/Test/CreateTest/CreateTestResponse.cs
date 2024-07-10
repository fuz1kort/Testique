namespace Testique.API.Application.Contracts.Test.CreateTest;

/// <summary>
/// Модель ответа на создание нового теста.
/// </summary>
public class CreateTestResponse
{
    /// <summary>
    /// ID созданного теста.
    /// </summary>
    public Guid TestId { get; set; }

    /// <summary>
    /// Сообщение о результате операции.
    /// </summary>
    public string Message { get; set; }
}