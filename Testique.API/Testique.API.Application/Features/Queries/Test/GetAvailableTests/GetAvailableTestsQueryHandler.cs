using MediatR;
using Microsoft.EntityFrameworkCore;
using Testique.API.Application.Contracts.Test.GetAvailableTests;
using Testique.API.Application.Interfaces;

namespace Testique.API.Application.Features.Queries.Test.GetAvailableTests;

public class GetAvailableTestsQueryHandler(IDbContext dbContext) : IRequestHandler<GetAvailableTestsQuery, GetAvailableTestsResponse>
{
    public async Task<GetAvailableTestsResponse> Handle(GetAvailableTestsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new Exception();

        var tests = await dbContext.Tests.Select(t => new GetAvailableTestsResponseItem
        {
            Id = t.Id,
            CreatorId = t.CreatorId,
            Name = t.Name
        })
        .ToListAsync(cancellationToken);

        return new GetAvailableTestsResponse
        {
            Items = tests
        };
    }
}