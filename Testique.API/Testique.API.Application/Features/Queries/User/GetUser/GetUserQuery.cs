using MediatR;

namespace Testique.API.Application.Features.Queries.User.GetUser;

/// <summary>
/// Запрос на получение <see cref="GetUserResponse"/>
/// </summary>
public class GetUserQuery : IRequest<GetUserResponse>
{
}