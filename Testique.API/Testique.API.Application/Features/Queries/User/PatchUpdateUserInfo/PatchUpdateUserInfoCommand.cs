using MediatR;

namespace Testique.API.Application.Features.Queries.User.PatchUpdateUserInfo;

public class PatchUpdateUserInfoCommand : PatchUpdateUserInfoRequest, IRequest<bool>
{
    public PatchUpdateUserInfoCommand(PatchUpdateUserInfoRequest request)
        : base(request)
    {
    }
}