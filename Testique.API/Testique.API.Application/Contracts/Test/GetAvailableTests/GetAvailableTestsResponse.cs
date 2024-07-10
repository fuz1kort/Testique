namespace Testique.API.Application.Contracts.Test.GetAvailableTests;

public class GetAvailableTestsResponse
{
    public List<GetAvailableTestsResponseItem> AvailableTests { get; set; } = default!;
}