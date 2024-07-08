using MediatR;

namespace Testique.API.Application.Features.Queries.Auth.PostLogin;

public class PostLoginCommand : PostLoginRequest, IRequest<PostLoginResponse>
{
    public PostLoginCommand(PostLoginRequest request)
        : base(request)
    {
    }
}