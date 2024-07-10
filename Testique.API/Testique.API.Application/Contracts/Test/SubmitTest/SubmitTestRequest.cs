using Testique.API.Domain.Entities;

namespace Testique.API.Application.Contracts.Test.SubmitTest;

public class SubmitTestRequest
{
    public Guid TestId { get; set; }
    public List<Answer> Answers { get; set; }
    public TimeSpan Time { get; set; }
    
    public SubmitTestRequest() {}

    public SubmitTestRequest(SubmitTestRequest request)
    {
        TestId = request.TestId;
        Answers = request.Answers;
        Time = request.Time;
    }
}