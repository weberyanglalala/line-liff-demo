using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Dotnet8LineRichMenu.Models.Perplexity.Dtos;
using Dotnet8LineRichMenu.Models.Settings;

namespace Dotnet8LineRichMenu.Services;

public class PerplexityService
{
    private readonly string _apiKey;
    private readonly string _endpoint;

    public PerplexityService(PerplexityApiSettings perplexityApiSettings)
    {
        _apiKey = perplexityApiSettings.ApiKey;
        _endpoint = perplexityApiSettings.Endpoint;
    }

    public async Task<ChatCompletionResponse> GetChatCompletion(string prompt)
    {
        var chatCompletionRequest = new ChatCompletionRequest
        {
            Messages = new List<MessageDto>
            {
                new MessageDto
                {
                    Role = "user",
                    Content = prompt
                }
            }
        };

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        var requestContent = new StringContent(JsonSerializer.Serialize(chatCompletionRequest), Encoding.UTF8,
            "application/json");
        var response = await httpClient.PostAsync(_endpoint, requestContent);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ChatCompletionResponse>(responseContent);
            return result;
        }
        else
        {
            throw new HttpRequestException(
                $"API request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
        }
    }
}