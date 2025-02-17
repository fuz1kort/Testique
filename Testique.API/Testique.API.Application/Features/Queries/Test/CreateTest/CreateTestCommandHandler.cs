﻿using MediatR;
using Testique.API.Application.Contracts.Test.CreateTest;
using Testique.API.Application.Interfaces;
using Testique.API.Domain.Entities;

namespace Testique.API.Application.Features.Queries.Test.CreateTest;

/// <summary>
/// Обработчик команды на создание нового теста.
/// </summary>
public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, CreateTestResponse>
{
    private readonly IDbContext _context;
    private readonly IUserContext _userContext;

    /// <summary>
    /// Конструктор для инициализации обработчика команды.
    /// </summary>
    /// <param name="context">Контекст базы данных.</param>
    /// <param name="userContext"></param>
    public CreateTestCommandHandler(IDbContext context, IUserContext userContext)
    {
        _context = context;
        _userContext = userContext;
    }

    /// <summary>
    /// Обрабатывает команду на создание нового теста.
    /// </summary>
    /// <param name="request">Команда на создание нового теста.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Ответ с информацией о созданном тесте.</returns>
    public async Task<CreateTestResponse> Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        var test = new Domain.Entities.Test
        {
            Name = request.Name,
            CreatedBy = _userContext.CurrentUserId,
            Description = request.Description,
            Time = request.Time,
            Questions = request.Questions.Select(q => new Question
            {
                Content = q.Content,
                Answers = q.Answers.Select(a => new Answer
                {
                    Content = a.Content,
                    IsCorrect = a.IsCorrect
                }).ToList()
            }).ToList()
        };

        _context.Tests.Add(test);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateTestResponse
        {
            TestId = test.Id,
            Message = "Test created successfully"
        };
    }
}