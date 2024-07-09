using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Testique.API.Domain.Entities;

namespace Testique.API.Application.Interfaces;

public interface IDbContext
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<IdentityUser> Users { get; set; }
    
    public DbSet<Test> Tests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<QuestionResult> QuestionResults { get; set; }

    /// <summary>
    /// Метод сохранения
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}