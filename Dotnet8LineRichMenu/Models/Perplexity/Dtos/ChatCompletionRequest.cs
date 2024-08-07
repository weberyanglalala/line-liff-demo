using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dotnet8LineRichMenu.Models.Perplexity.Dtos;

public class ChatCompletionRequest
{
    [JsonPropertyName("model")]
    [Required]
    public string Model { get; set; } = "llama-3.1-sonar-small-128k-online";

    [JsonPropertyName("messages")]
    [Required]
    public List<MessageDto> Messages { get; set; }

    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; } = 2000;

    [JsonPropertyName("temperature")]
    public double? Temperature { get; set; } = 1;

    [JsonPropertyName("top_p")]
    public double? TopP { get; set; } = 0.9;

    [JsonPropertyName("return_citations")]
    public bool? ReturnCitations { get; set; } = true;

    [JsonPropertyName("search_domain_filter")]
    public List<string> SearchDomainFilter { get; set; }

    [JsonPropertyName("return_images")]
    public bool? ReturnImages { get; set; } = false;

    [JsonPropertyName("return_related_questions")]
    public bool? ReturnRelatedQuestions { get; set; } = false;

    [JsonPropertyName("top_k")]
    public int? TopK { get; set; } = 0;

    [JsonPropertyName("stream")]
    public bool? Stream { get; set; } = false;

    [JsonPropertyName("presence_penalty")]
    public double? PresencePenalty { get; set; } = 0;

    [JsonPropertyName("frequency_penalty")]
    public double? FrequencyPenalty { get; set; } = 1;
}

public class MessageDto
{
    [JsonPropertyName("role")]
    [Required]
    public string Role { get; set; }

    [JsonPropertyName("content")]
    [Required]
    public string Content { get; set; }
}