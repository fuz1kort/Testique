namespace Testique.API.Application.Contracts.Auth.PostLogin;

/// <summary>
/// Ответ на вход
/// </summary>
public class PostLoginResponse
{
    /// <summary>
    /// Успешно ли
    /// </summary>
    public bool IsSucceed { get; set; }

    /// <summary>
    /// Ошибки
    /// </summary>
    public string? Error { get; set; }
}