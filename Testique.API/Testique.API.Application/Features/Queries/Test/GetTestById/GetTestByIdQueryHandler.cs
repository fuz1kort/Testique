using MediatR;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Contracts.Test.CreateTest;
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

        var test = await dbContext.Tests.Include(t => t.Questions)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (test is null)
            throw new Exception();

        return new GetTestByIdResponse
        {
            CreatorId = test.CreatorId,
            Questions = test.Questions.Select(q =>
            {
                new QuestionDto
                {
                    Answers = q.Answers.Select(a =>
                    {
                        new AnswerDto
                        {
                            Content = a.Content,
                            IsCorrect = a.IsCorrect
                        };
                    }),
                    Content = q.Content
                };
            }),
                
            Id = test.Id,
            Name = test.Name
        };
    }
}