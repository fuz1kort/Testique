using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Testique.API.Application.Interfaces;

namespace Testique.API.Infrastructure.Services;

/// <summary>
/// Контекст пользователя
/// </summary>
public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Контекст
    /// </summary>
    /// <param name="httpContextAccessor">Аксессор http</param>
    public UserContext(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    private string? _currentUserId;

    private string? _roleName;

    /// <inheritdoc />
    public string? CurrentUserId
    {
        get
        {
            _currentUserId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _currentUserId;
        }
    }

    /// <inheritdoc />
    public string? RoleName
    {
        get
        {
            _roleName ??= User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            return _roleName;
        }
    }
    
    /// <summary>
    /// Клаймы текущего пользователя
    /// </summary>
    private ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
}