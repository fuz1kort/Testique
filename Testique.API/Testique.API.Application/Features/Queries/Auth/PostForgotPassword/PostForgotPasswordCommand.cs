using MediatR;
using Testique.API.Application.Contracts.Auth.PostForgotPassword;

namespace Testique.API.Application.Features.Queries.Auth.PostForgotPassword;

public class PostForgotPasswordCommand : PostForgotPasswordRequest, IRequest<Unit>
{
    public PostForgotPasswordCommand(PostForgotPasswordRequest request)
        : base(request)
    {
    }
}