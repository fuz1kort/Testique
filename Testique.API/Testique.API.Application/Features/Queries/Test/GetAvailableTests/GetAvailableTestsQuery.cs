using MediatR;
using Testique.API.Application.Contracts.Test.GetAvailableTests;

namespace Testique.API.Application.Features.Queries.Test.GetAvailableTests;

public class GetAvailableTestsQuery: IRequest<GetAvailableTestsResponse>
{
}