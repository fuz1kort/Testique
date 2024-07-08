namespace Testique.API.Application.Contracts.Auth.PutResetPassword;

public class PutResetPasswordRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public PutResetPasswordRequest()
    {
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutResetPasswordRequest(PutResetPasswordRequest request)
    {
        UserId = request.UserId;
        Token = request.Token;
        NewPassword = request.NewPassword;
    }
    
    public string UserId { get; set; } = default!;
    public string Token { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
}