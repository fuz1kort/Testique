using MediatR;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Contracts.Test.SubmitTest;
using Testique.API.Application.Interfaces;
using Testique.API.Application.Models;
using Testique.API.Domain.Entities;

namespace Testique.API.Application.Features.Queries.Test.SubmitTest;

public class SubmitTestCommandHandler(IDbContext context, IUserContext userContext)
    : IRequestHandler<SubmitTestCommand, SubmitTestResponse>
{
    public async Task<SubmitTestResponse> Handle(SubmitTestCommand request, CancellationToken cancellationToken)
    {
        // Получение ID пользователя из контекста HTTP
        var userId = userContext.CurrentUserId;
        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException();

        // Загрузка теста вместе с вопросами и ответами
        var test = await context.Tests
            .Include(t => t.Questions)
            .ThenInclude(q => q.Answers)
            .FirstOrDefaultAsync(t => t.Id == request.TestId, cancellationToken);

        if (test is null)
            throw new KeyNotFoundException("Test not found.");

        // Подсчет очков и сбор результатов вопросов
        var score = 0;
        var questionResults = new List<QuestionResult>();

        foreach (var answer in request.Answers)
        {
            var question = test.Questions.FirstOrDefault(q => q.Id == answer.QuestionId);
            if (question is null)
                continue;

            var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
            var isCorrect = correctAnswer != null && correctAnswer.Id == answer.Id;
            if (isCorrect) 
                score++;

            questionResults.Add(new QuestionResult
            {
                QuestionId = question.Id,
                SelectedAnswerId = answer.Id,
                IsCorrect = isCorrect
            });
        }

        // Создание результата теста
        var testResult = new TestResult
        {
            Id = test.Id,
            UserId = userId,
            Time = request.Time,
            Score = score,
            QuestionResults = questionResults
        };

        // Сохранение результата теста в базе данных
        context.TestResults.Add(testResult);
        await context.SaveChangesAsync(cancellationToken);

        // Возврат результата
        return new SubmitTestResponse
        {
            TestResult = new TestResultDto
            {
                QuestionResults = testResult.QuestionResults.Select(qr => new QuestionResultDto
                {
                    IsCorrect = qr.IsCorrect,
                    QuestionContent = qr.QuestionContent,
                    QuestionId = qr.QuestionId,
                    SelectedAnswerId = qr.SelectedAnswerId
                }).ToList(),
                Score = testResult.Score,
                TestId = testResult.Id,
                TestName = testResult.TestName,
                Time = testResult.Time,
                UserId = testResult.UserId
            }
        };
    }
}