using Newtonsoft.Json.Linq;

namespace HigLabo.OpenAI;

/// <summary>Compacts a conversation into a canonical context window for the next Responses request.</summary>
public class ResponseCompactParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod => "POST";
    string IRestApiParameter.GetApiPath() => "/responses/compact";
    public string Model { get; set; } = "";
    public object? Input { get; set; }
    public ResponseImageOptions? Image { get; set; }
    public string? Instructions { get; set; }
    public string? Previous_Response_Id { get; set; }
    public string? Prompt_Cache_Key { get; set; }
    public PromptCacheOptions? Prompt_Cache_Options { get; set; }
    public string? Prompt_Cache_Retention { get; set; }
    public string? Service_Tier { get; set; }

    public override object GetRequestBody() => new
    {
        model = Model, input = Input, image = Image, instructions = Instructions,
        previous_response_id = Previous_Response_Id, prompt_cache_key = Prompt_Cache_Key,
        prompt_cache_options = Prompt_Cache_Options, prompt_cache_retention = Prompt_Cache_Retention,
        service_tier = Service_Tier,
    };
}

public class ResponseCompactResponse : RestApiResponse
{
    public string Id { get; set; } = "";
    public long Created_At { get; set; }
    /// <summary>Pass the entire window to the next request, including retained messages and encrypted items.</summary>
    public JArray Output { get; set; } = new();
    public ResponseUsageResult? Usage { get; set; }
}

public partial class OpenAIClient
{
    public ValueTask<ResponseCompactResponse> ResponseCompactAsync(ResponseCompactParameter parameter)
        => ResponseCompactAsync(parameter, CancellationToken.None);

    public ValueTask<ResponseCompactResponse> ResponseCompactAsync(ResponseCompactParameter parameter, CancellationToken cancellationToken)
        => SendJsonAsync<ResponseCompactParameter, ResponseCompactResponse>(parameter, cancellationToken);
}
