using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Interfaces;

namespace Testique.API.Persistence.Context;

public class EfContext : IdentityDbContext, IDbContext
{
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public EfContext()
    {
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public EfContext(DbContextOptions options)
        : base(options)
    {
    }
}