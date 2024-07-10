using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Interfaces;
using Testique.API.Domain.Entities;

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

    /// <summary>
    /// Набор данных для таблицы "Tests", представляющей тесты.
    /// </summary>
    public DbSet<Test> Tests { get; set; }

    /// <summary>
    /// Набор данных для таблицы "Questions", представляющей вопросы.
    /// </summary>
    public DbSet<Question> Questions { get; set; }

    /// <summary>
    /// Набор данных для таблицы "Answers", представляющей ответы на вопросы.
    /// </summary>
    public DbSet<Answer> Answers { get; set; }

    /// <summary>
    /// Набор данных для таблицы "TestResults", представляющей результаты тестов.
    /// </summary>
    public DbSet<TestResult> TestResults { get; set; }

    /// <summary>
    /// Набор данных для таблицы "QuestionResults", представляющей результаты ответов на вопросы.
    /// </summary>
    public DbSet<QuestionResult> QuestionResults { get; set; }

    /// <summary>
    /// Конфигурирование моделей и их связей.
    /// </summary>
    /// <param name="modelBuilder">Построитель моделей для конфигурирования сущностей.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка отношений между таблицей "Tests" и таблицей "Questions".
        modelBuilder.Entity<Test>()
            .HasMany(t => t.Questions)
            .WithOne(q => q.Test)
            .HasForeignKey(q => q.TestId);

        // Настройка отношений между таблицей "Tests" и таблицей "Users".
        modelBuilder.Entity<Test>()
            .HasOne(t => t.Creator)
            .WithMany()
            .HasForeignKey(t => t.CreatedBy);

        // Настройка отношений между таблицей "Questions" и таблицей "Answers".
        modelBuilder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

        // Настройка отношений между таблицей "TestResults" и таблицей "QuestionResults".
        modelBuilder.Entity<TestResult>()
            .HasMany(tr => tr.QuestionResults)
            .WithOne()
            .HasForeignKey(qr => qr.TestResultId);

        // Настройка отношений между таблицей "TestResults" и таблицей "Users".
        modelBuilder.Entity<TestResult>()
            .HasOne(tr => tr.User)
            .WithMany()
            .HasForeignKey(tr => tr.UserId);

        base.OnModelCreating(modelBuilder);
    }
}