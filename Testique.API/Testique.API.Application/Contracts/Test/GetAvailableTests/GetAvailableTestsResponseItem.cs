namespace Testique.API.Application.Contracts.Test.GetAvailableTests;

public class GetAvailableTestsResponseItem
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название теста.
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    /// Идентификатор создателя теста.
    /// </summary>
    public Guid CreatorId { get; set; }
}