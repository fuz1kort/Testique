using MediatR;
using Testique.API.Application.Contracts.Auth.GetConfirmEmail;

namespace Testique.API.Application.Features.Queries.Auth.GetConfirmEmail;

public class GetConfirmEmailQuery : GetConfirmEmailRequest, IRequest<GetConfirmEmailResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public GetConfirmEmailQuery(GetConfirmEmailRequest request) 
        : base(request)
    {
    }
}