using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testique.API.Application.Interfaces;
using Testique.API.Application.Models;
using Testique.API.Infrastructure.Services;

namespace Testique.API.Infrastructure;

public static class Entry
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddScoped<IUserContext, UserContext>();
        serviceCollection.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        serviceCollection.AddTransient<IEmailSender, EmailSender>();
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}