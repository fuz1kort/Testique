using Microsoft.AspNetCore.Identity;
using Testique.API.Application.Contracts.Test.CreateTest;
using Testique.API.Application.Models;
using Testique.API.Domain.Entities;

namespace Testique.API.Application.Contracts.Test.GetTestById;

public class GetTestByIdResponse
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название теста.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Список вопросов, содержащихся в тесте.
    /// </summary>
    public List<QuestionDto> Questions { get; set; } = default!;
    
    /// <summary>
    /// Идентификатор создателя теста.
    /// </summary>
    public string CreatorId { get; set; }
}