using Dotnet8LineRichMenu.Models.Api.Perplexity;
using Dotnet8LineRichMenu.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8LineRichMenu.WebApi;

[Route("/api/[controller]/[action]")]
[ApiController]
public class PerplexityController : ControllerBase
{
    private readonly PerplexityService _perplexityService;
    private readonly ILogger<PerplexityController> _logger;

    public PerplexityController(PerplexityService perplexityService, ILogger<PerplexityController> logger)
    {
        _perplexityService = perplexityService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> GetChatCompletion(GetCompletionRequest request)
    {
        try
        {
            var chatResponse = await _perplexityService.GetChatCompletion(request.Prompt);
            var assistantResponse = chatResponse.Choices.FirstOrDefault(x => x.FinishReason == "stop");
            return Ok(new GetChatCompletionResponse()
            {
                Output = assistantResponse?.Message.Content
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error occurred while getting chat completion");
            return Ok(new GetChatCompletionResponse()
            {
                Output = "API Error occurred while getting chat completion!"
            });
        }
    }
}