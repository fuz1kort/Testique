namespace Testique.API.Application.Contracts.Auth.GetConfirmEmail;

public class GetConfirmEmailRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public GetConfirmEmailRequest()
    {
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public GetConfirmEmailRequest(GetConfirmEmailRequest request)
    {
        UserId = request.UserId;
        Token = request.Token;
    }
    
    public string UserId { get; set; } = default!;
    public string Token { get; set; } = default!;
}