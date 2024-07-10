using MediatR;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Contracts.Test.GetTestById;
using Testique.API.Application.Interfaces;
using Testique.API.Application.Models;

namespace Testique.API.Application.Features.Queries.Test.GetTestById;

public class GetTestByIdQueryHandler(IDbContext dbContext)
    : IRequestHandler<GetTestByIdQuery, GetTestByIdResponse>
{
    public async Task<GetTestByIdResponse> Handle(GetTestByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        var test = await dbContext.Tests.Include(t => t.Questions).ThenInclude(q => q.Answers)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (test is null)
            throw new Exception();

        var questionDtos = test.Questions.Select(q => new QuestionDto
        {
            Content = q.Content,
            Answers = q.Answers.Select(a => new AnswerDto
            {
                Content = a.Content,
                IsCorrect = a.IsCorrect
            }).ToList()
        }).ToList();

        return new GetTestByIdResponse
        {
            Id = test.Id,
            Name = test.Name,
            CreatorId = test.CreatedBy ?? "unknown",
            Questions = questionDtos
        };
    }
}