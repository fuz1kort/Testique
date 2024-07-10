using MediatR;
using Testique.API.Application.Contracts.Test.CreateTest;

namespace Testique.API.Application.Features.Queries.Test.CreateTest;

/// <summary>
/// Команда на создание нового теста.
/// </summary>
public class CreateTestCommand : CreateTestRequest, IRequest<CreateTestResponse>
{
    public CreateTestCommand(CreateTestRequest request)
        : base(request)
    {
    }
}