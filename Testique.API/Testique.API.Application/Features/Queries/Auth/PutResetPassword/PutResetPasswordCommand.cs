using MediatR;
using Testique.API.Application.Contracts.Auth.PutResetPassword;

namespace Testique.API.Application.Features.Queries.Auth.PutResetPassword;

public class PutResetPasswordCommand: PutResetPasswordRequest, IRequest<PutResetPasswordResponse>
{
    public PutResetPasswordCommand(PutResetPasswordRequest request)
        : base(request)
    {
    }
}