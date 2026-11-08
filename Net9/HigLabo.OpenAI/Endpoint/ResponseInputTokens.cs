namespace HigLabo.OpenAI;

/// <summary>Counts input tokens without generating a model response.</summary>
public class ResponseInputTokensParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod => "POST";
    string IRestApiParameter.GetApiPath() => "/responses/input_tokens";
    public object? Conversation { get; set; }
    public object? Input { get; set; }
    public string? Instructions { get; set; }
    public string? Model { get; set; }
    public bool? Parallel_Tool_Calls { get; set; }
    public string? Personality { get; set; }
    public string? Previous_Response_Id { get; set; }
    public Reasoning? Reasoning { get; set; }
    public object? Text { get; set; }
    public object? Tool_Choice { get; set; }
    public List<Tool>? Tools { get; set; }
    public string? Truncation { get; set; }

    public override object GetRequestBody() => new
    {
        conversation = Conversation, input = Input, instructions = Instructions, model = Model,
        parallel_tool_calls = Parallel_Tool_Calls, personality = Personality,
        previous_response_id = Previous_Response_Id, reasoning = Reasoning, text = Text,
        tool_choice = Tool_Choice, tools = Tools, truncation = Truncation,
    };
}

public class ResponseInputTokensResponse : RestApiResponse
{
    public int Input_Tokens { get; set; }
}

public partial class OpenAIClient
{
    public ValueTask<ResponseInputTokensResponse> ResponseInputTokensAsync(ResponseInputTokensParameter parameter)
        => ResponseInputTokensAsync(parameter, CancellationToken.None);

    public ValueTask<ResponseInputTokensResponse> ResponseInputTokensAsync(ResponseInputTokensParameter parameter, CancellationToken cancellationToken)
        => SendJsonAsync<ResponseInputTokensParameter, ResponseInputTokensResponse>(parameter, cancellationToken);
}
