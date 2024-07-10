using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Testique.API.Application.Contracts.Test.CreateTest;
using Testique.API.Application.Contracts.Test.GetAvailableTests;
using Testique.API.Application.Contracts.Test.GetTestById;
using Testique.API.Application.Features.Queries.Test.CreateTest;
using Testique.API.Application.Features.Queries.Test.GetAvailableTests;
using Testique.API.Application.Features.Queries.Test.GetTestById;

namespace Testique.API.WEB.Controllers;

/// <summary>
/// Контроллер отвечающий за действия с тестами
/// </summary>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="mediator">Медиатор из библиотеки MediatR</param>
    public TestController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Возвращает все доступные тесты
    /// </summary>
    [AllowAnonymous]
    [HttpGet("GetAvailableTests")]
    public async Task<GetAvailableTestsResponse> GetAvailableTests()
        => await _mediator.Send(new GetAvailableTestsQuery());

    /// <summary>
    /// Возвращает тест по ID
    /// </summary>
    [HttpGet("GetTestById/{testId:guid}")]
    public async Task<GetTestByIdResponse> GetTestById(Guid testId) 
        => await _mediator.Send(new GetTestByIdQuery(testId));
    
    /// <summary>
    /// Создает новый тест
    /// </summary>
    [HttpPost("CreateTest")]
    public async Task<CreateTestResponse> CreateTest(CreateTestRequest request) 
        => await _mediator.Send(new CreateTestCommand(request));
}