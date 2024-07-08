namespace Testique.API.Application.Contracts.Auth.PostForgotPassword;

public class PostForgotPasswordRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public PostForgotPasswordRequest()
    {
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostForgotPasswordRequest(PostForgotPasswordRequest request) 
        => Email = request.Email;

    public string Email { get; set; } = default!;
}