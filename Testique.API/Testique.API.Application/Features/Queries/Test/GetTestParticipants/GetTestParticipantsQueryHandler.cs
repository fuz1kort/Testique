using MediatR;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Contracts.Test.GetTestParticipants;
using Testique.API.Application.Interfaces;
using Testique.API.Application.Models;

namespace Testique.API.Application.Features.Queries.Test.GetTestParticipants;

public class GetTestParticipantsQueryHandler(IDbContext context, IUserContext userContext)
    : IRequestHandler<GetTestParticipantsQuery, GetTestParticipantsResponse>
{
    public async Task<GetTestParticipantsResponse> Handle(GetTestParticipantsQuery request,
        CancellationToken cancellationToken)
    {
        var testResults = await context.TestResults
            .Where(tr => tr.Id == request.Id)
            .Include(tr => tr.User)
            .Include(tr => tr.Test)
            .Where(tr => tr.Test.CreatedBy.Equals(userContext.CurrentUserId))
            .Include(tr => tr.QuestionResults)
            .ToListAsync(cancellationToken);

        var participants = testResults.Select(tr => new TestResultDto
        {
            TestId = tr.Id,
            TestName = tr.TestName,
            UserId = tr.User.Id,
            QuestionResults = tr.QuestionResults.Select(qr => new QuestionResultDto
            {
                IsCorrect = qr.IsCorrect,
                QuestionContent = qr.QuestionContent,
                QuestionId = qr.QuestionId,
                SelectedAnswerId = qr.SelectedAnswerId,
            }).ToList(),
            Score = tr.Score,
            Time = tr.Time
        }).ToList();

        return new GetTestParticipantsResponse
        {
            ParticipantsResult = participants
        };
    }
}