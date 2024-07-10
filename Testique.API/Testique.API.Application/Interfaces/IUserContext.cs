namespace Testique.API.Application.Interfaces;

/// <summary>
/// Контекс текущего пользоавтеля
/// </summary>
public interface IUserContext
{
    /// <summary>
    /// ИД текущего пользователя
    /// </summary>
    string? CurrentUserId { get; }
    
    /// <summary>
    /// Название роли текущего пользователя
    /// </summary>
    string? RoleName { get; }
}