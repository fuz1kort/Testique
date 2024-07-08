using MediatR;

namespace Testique.API.Application.Features.Queries.Auth.PutResetPassword;

public class PutResetPasswordCommand: PutResetPasswordRequest, IRequest<PutResetPasswordResponse>
{
    public PutResetPasswordCommand(PutResetPasswordRequest request)
        : base(request)
    {
    }
}