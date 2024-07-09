using Microsoft.EntityFrameworkCore;

namespace Testique.API.Persistence.Context;

/// <summary>
/// Скрипт для накатывания миграций
/// </summary>
public class Migrator
{
    private readonly EfContext _efContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="efContext">Контекст БД</param>
    public Migrator(EfContext efContext) 
        => _efContext = efContext;

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _efContext.Database.MigrateAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}