namespace Testique.API.Application.Contracts.Auth.GetConfirmEmail;

/// <summary>
/// Ответ на подтверждение почты
/// </summary>
public class GetConfirmEmailResponse
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