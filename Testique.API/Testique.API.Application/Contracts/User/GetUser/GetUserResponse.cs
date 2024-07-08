namespace Testique.API.Application.Contracts.User.GetUser;

/// <summary>
/// Ответ для запроса на получение информации о пользователе
/// </summary>
public class GetUserResponse
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string UserName { get; set; } = default!;

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = default!;
}