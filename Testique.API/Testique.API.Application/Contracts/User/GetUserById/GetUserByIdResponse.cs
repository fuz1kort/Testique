namespace Testique.API.Application.Contracts.User.GetUserById;

/// <summary>
/// Ответ на запрос пользователя
/// </summary>
public class GetUserByIdResponse
{
    /// <summary>
    /// ИД
    /// </summary>
    public string Id { get; set; } = default!;
    
    /// <summary>
    /// Никнейм
    /// </summary>
    public string UserName { get; set; } = default!;
}