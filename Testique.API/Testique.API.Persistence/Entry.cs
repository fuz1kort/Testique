using Microsoft.Extensions.DependencyInjection;
using Testique.API.Application.Interfaces;
using Testique.API.Persistence.Context;

namespace Testique.API.Persistence;

public static class Entry
{
    public static void AddPersistenceLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<EfContext>();
        serviceCollection.AddScoped<IDbContext, EfContext>();
        serviceCollection.AddTransient<Migrator>();
        serviceCollection.AddLogging();
    }
}