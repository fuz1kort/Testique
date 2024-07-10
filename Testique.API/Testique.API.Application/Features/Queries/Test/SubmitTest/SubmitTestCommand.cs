using MediatR;
using Testique.API.Application.Contracts.Test.SubmitTest;

namespace Testique.API.Application.Features.Queries.Test.SubmitTest;

public class SubmitTestCommand : SubmitTestRequest, IRequest<SubmitTestResponse>
{
    public SubmitTestCommand(SubmitTestRequest request)
        : base(request)
    {
    }
}