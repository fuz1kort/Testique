using MediatR;
using Testique.API.Application.Contracts.Auth.PostRegister;

namespace Testique.API.Application.Features.Queries.Auth.PostRegister;

public class PostRegisterCommand : PostRegisterRequest, IRequest<Unit>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostRegisterCommand(PostRegisterRequest request)
        : base(request)
    {
    }
}