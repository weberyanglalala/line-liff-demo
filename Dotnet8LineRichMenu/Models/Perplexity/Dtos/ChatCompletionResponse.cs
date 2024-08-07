using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dotnet8LineRichMenu.Models.Perplexity.Dtos;

public class ChatCompletionResponse
{
    [JsonPropertyName("id")]
    [Required]
    public string Id { get; set; }

    [JsonPropertyName("model")]
    [Required]
    public string Model { get; set; }

    [JsonPropertyName("object")]
    [Required]
    public string Object { get; set; }

    [JsonPropertyName("created")]
    [Required]
    public int Created { get; set; }

    [JsonPropertyName("choices")]
    [Required]
    public List<ChoiceDto> Choices { get; set; }

    [JsonPropertyName("usage")]
    public UsageDto Usage { get; set; }
}

public class ChoiceDto
{
    [JsonPropertyName("index")]
    [Required]
    public int Index { get; set; }

    [JsonPropertyName("finish_reason")]
    [Required]
    public string FinishReason { get; set; }

    [JsonPropertyName("message")]
    public MessageDto Message { get; set; }

    [JsonPropertyName("delta")]
    public MessageDto Delta { get; set; }
}

public class UsageDto
{
    [JsonPropertyName("prompt_tokens")]
    [Required]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    [Required]
    public int CompletionTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    [Required]
    public int TotalTokens { get; set; }
}