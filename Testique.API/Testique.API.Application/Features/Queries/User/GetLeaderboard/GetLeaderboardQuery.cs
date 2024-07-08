using MediatR;

namespace Testique.API.Application.Features.Queries.User.GetLeaderboard;

public class GetLeaderboardQuery: GetLeaderboardRequest  ,IRequest<GetLeaderboardResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request"></param>
    public GetLeaderboardQuery(GetLeaderboardRequest request)
        : base(request)
    {
    }
}