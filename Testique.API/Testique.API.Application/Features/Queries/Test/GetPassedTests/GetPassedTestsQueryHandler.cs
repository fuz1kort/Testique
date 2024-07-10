using MediatR;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Contracts.Test.GetPassedTests;
using Testique.API.Application.Interfaces;
using Testique.API.Application.Models;

namespace Testique.API.Application.Features.Queries.Test.GetPassedTests;

/// <summary>
/// Обработчик для получения пройденных тестов и их результатов.
/// </summary>
public class GetPassedTestsQueryHandler(IDbContext context, IUserContext userContext)
    : IRequestHandler<GetPassedTestsQuery, GetPassedTestsResponse>
{
    public async Task<GetPassedTestsResponse> Handle(GetPassedTestsQuery request, CancellationToken cancellationToken)
    {
        var testResults = await context.TestResults
            .Where(tr => tr.UserId == userContext.CurrentUserId)
            .Include(tr => tr.QuestionResults)
            .ToListAsync(cancellationToken);

        var testResultDtos = testResults.Select(tr => new TestResultDto
        {
            TestId = tr.Id,
            TestName = tr.TestName,
            Score = tr.Score,
            Time = tr.Time,
            QuestionResults = tr.QuestionResults.Select(qr => new QuestionResultDto
            {
                QuestionId = qr.QuestionId,
                QuestionContent = qr.QuestionContent,
                SelectedAnswerId = qr.SelectedAnswerId,
                IsCorrect = qr.IsCorrect
            }).ToList()
        }).ToList();

        return new GetPassedTestsResponse
        {
            TestResults = testResultDtos
        };
    }
}