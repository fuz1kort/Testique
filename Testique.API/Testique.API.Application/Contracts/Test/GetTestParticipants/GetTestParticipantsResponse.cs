using Testique.API.Application.Models;

namespace Testique.API.Application.Contracts.Test.GetTestParticipants;

public class GetTestParticipantsResponse
{
    public List<TestResultDto> ParticipantsResult { get; set; } = default!;
}