namespace Testique.API.Application.Contracts.Auth.PutResetPassword;

public class PutResetPasswordResponse
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