namespace Testique.API.Application.Contracts.Test.GenerateTestLink;

/// <summary>
/// Ответ с ссылкой на прохождение теста.
/// </summary>
public class GenerateTestLinkResponse
{
    public string TestLink { get; set; } = default!;
}