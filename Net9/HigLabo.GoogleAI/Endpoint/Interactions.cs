using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace HigLabo.GoogleAI;

public partial class InteractionsCreateParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Model { get; set; } = "";
    public string Agent { get; set; } = "";
    public object? Input { get; set; }
    public string? SystemInstruction { get; set; }
    public List<InteractionTool>? Tools { get; set; }
    public object? ResponseFormat { get; set; }
    public string? ResponseMimeType { get; set; }
    public bool? Stream { get; set; }
    public bool? Store { get; set; }
    public bool? Background { get; set; }
    public object? GenerationConfig { get; set; }
    public object? AgentConfig { get; set; }
    public object? Environment { get; set; }
    public string? PreviousInteractionId { get; set; }
    public object? ResponseModalities { get; set; }
    public string? ServiceTier { get; set; }
    public InteractionsWebhookConfig? WebhookConfig { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        return "interactions";
    }
    public override object GetRequestBody()
    {
        return new
        {
            model = this.Model.IsNullOrEmpty() ? null : this.Model,
            agent = this.Agent.IsNullOrEmpty() ? null : this.Agent,
            input = this.Input,
            system_instruction = this.SystemInstruction,
            tools = this.Tools,
            response_format = this.ResponseFormat,
            response_mime_type = this.ResponseMimeType,
            stream = this.Stream,
            store = this.Store,
            background = this.Background,
            generation_config = this.GenerationConfig,
            agent_config = this.AgentConfig,
            environment = this.Environment,
            previous_interaction_id = this.PreviousInteractionId,
            response_modalities = this.ResponseModalities,
            service_tier = this.ServiceTier,
            webhook_config = this.WebhookConfig,
        };
    }
    public void SetInput(string text)
    {
        this.Input = text;
    }
    public void SetInput(params InteractionContent[] content)
    {
        this.Input = content.ToList();
    }
    public void SetInput(IEnumerable<InteractionStep> steps)
    {
        this.Input = steps.ToList();
    }
}
public partial class InteractionsGetParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "GET";

    public string Id { get; set; } = "";
    public bool? Stream { get; set; }
    public string? LastEventId { get; set; }
    public bool? IncludeInput { get; set; }
    public string? ApiVersion { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        var query = InteractionsQueryString.Create(
            ("stream", this.Stream),
            ("last_event_id", this.LastEventId),
            ("include_input", this.IncludeInput),
            ("api_version", this.ApiVersion));
        return query.IsNullOrEmpty() ? $"interactions/{this.Id}" : $"interactions/{this.Id}?{query}";
    }
    public override object GetRequestBody()
    {
        return new { };
    }
}
public partial class InteractionsDeleteParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "DELETE";

    public string Id { get; set; } = "";
    public string? ApiVersion { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        var query = InteractionsQueryString.Create(("api_version", this.ApiVersion));
        return query.IsNullOrEmpty() ? $"interactions/{this.Id}" : $"interactions/{this.Id}?{query}";
    }
    public override object GetRequestBody()
    {
        return new { };
    }
}
public partial class InteractionsCancelParameter : RestApiParameter, IRestApiParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Id { get; set; } = "";
    public string? ApiVersion { get; set; }

    string IRestApiParameter.GetApiPath()
    {
        var query = InteractionsQueryString.Create(("api_version", this.ApiVersion));
        return query.IsNullOrEmpty() ? $"interactions/{this.Id}/cancel" : $"interactions/{this.Id}/cancel?{query}";
    }
    public override object GetRequestBody()
    {
        return new { };
    }
}
public class InteractionsCreateResponse : InteractionObject
{
}
public class InteractionsGetResponse : InteractionObject
{
}
public class InteractionsDeleteResponse : RestApiResponse
{
}
public class InteractionsCancelResponse : InteractionObject
{
}
public class InteractionObject : RestApiResponse
{
    public string Id { get; set; } = "";
    public new string Object { get; set; } = "";
    public string Model { get; set; } = "";
    public string Agent { get; set; } = "";
    public string Status { get; set; } = "";
    public string Created { get; set; } = "";
    public string Updated { get; set; } = "";
    public List<InteractionStep> Steps { get; init; } = new();
    public InteractionUsage Usage { get; set; } = new();
    [JsonProperty("previous_interaction_id")]
    public string PreviousInteractionId { get; set; } = "";

    public string GetOutputText()
    {
        var sb = new System.Text.StringBuilder();
        foreach (var step in this.Steps)
        {
            if (string.Equals(step.Type, "model_output", StringComparison.OrdinalIgnoreCase) == false) { continue; }
            foreach (var item in step.Content)
            {
                if (string.Equals(item.Type, "text", StringComparison.OrdinalIgnoreCase))
                {
                    sb.Append(item.Text);
                }
            }
        }
        return sb.ToString();
    }
    public List<InteractionStep> GetFunctionCallList()
    {
        return this.Steps.FindAll(el => string.Equals(el.Type, "function_call", StringComparison.OrdinalIgnoreCase));
    }
}
public class InteractionStep
{
    public string Type { get; set; } = "";
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    [JsonProperty("call_id")]
    public string CallId { get; set; } = "";
    public List<InteractionContent> Content { get; init; } = new();
    public List<InteractionContent> Summary { get; init; } = new();
    public JToken? Arguments { get; set; }
    public JToken? Result { get; set; }
    public string Signature { get; set; } = "";
}
public class InteractionContent
{
    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
    [JsonProperty("mime_type")]
    public string MimeType { get; set; } = "";
    public string Url { get; set; } = "";
    public string Uri { get; set; } = "";
    [JsonProperty("file_uri")]
    public string FileUri { get; set; } = "";
    [JsonProperty("file_name")]
    public string FileName { get; set; } = "";
    public string Name { get; set; } = "";
    [JsonProperty("call_id")]
    public string CallId { get; set; } = "";
    public JToken? Data { get; set; }
    public JToken? Arguments { get; set; }
    public JToken? Result { get; set; }

    public InteractionContent() { }
    public InteractionContent(string text)
    {
        this.Type = "text";
        this.Text = text;
    }
}
public class InteractionUsage
{
    [JsonProperty("input_tokens_by_modality")]
    public List<InteractionModalityTokenCount> InputTokensByModality { get; set; } = new();
    [JsonProperty("output_tokens_by_modality")]
    public List<InteractionModalityTokenCount> OutputTokensByModality { get; set; } = new();
    [JsonProperty("total_cached_tokens")]
    public int TotalCachedTokens { get; set; }
    [JsonProperty("total_input_tokens")]
    public int TotalInputTokens { get; set; }
    [JsonProperty("total_output_tokens")]
    public int TotalOutputTokens { get; set; }
    [JsonProperty("total_thought_tokens")]
    public int TotalThoughtTokens { get; set; }
    [JsonProperty("total_tokens")]
    public int TotalTokens { get; set; }
    [JsonProperty("total_tool_use_tokens")]
    public int TotalToolUseTokens { get; set; }
}
public class InteractionModalityTokenCount
{
    public string Modality { get; set; } = "";
    public int Tokens { get; set; }
}
public class InteractionsWebhookConfig
{
    public List<string> Uris { get; init; } = new();
    public object? UserMetadata { get; set; }
}
public class InteractionStreamResult
{
    public List<InteractionStreamEvent> EventList { get; init; } = new();
    public InteractionObject? Interaction { get; set; }
    public List<InteractionStreamEvent> StepStartList { get; init; } = new();
    public List<InteractionStreamEvent> StepDeltaList { get; init; } = new();
    public List<InteractionStreamEvent> StepStopList { get; init; } = new();

    public void Process(InteractionStreamEvent streamEvent)
    {
        this.EventList.Add(streamEvent);
        if (streamEvent.Interaction != null)
        {
            this.Interaction = streamEvent.Interaction;
        }
        switch (streamEvent.EventType)
        {
            case "step.start":
                this.StepStartList.Add(streamEvent);
                break;
            case "step.delta":
                this.StepDeltaList.Add(streamEvent);
                break;
            case "step.stop":
                this.StepStopList.Add(streamEvent);
                break;
        }
    }
    public string GetText()
    {
        var sb = new System.Text.StringBuilder();
        foreach (var item in this.StepDeltaList)
        {
            if (string.Equals(item.Delta.Type, "text", StringComparison.OrdinalIgnoreCase))
            {
                sb.Append(item.Delta.Text);
            }
        }
        return sb.ToString();
    }
    public InteractionUsage? GetUsageResult()
    {
        return this.Interaction?.Usage;
    }
    public List<InteractionStreamEvent> GetFunctionCallList()
    {
        return this.StepDeltaList.FindAll(el => string.Equals(el.Delta.Type, "function_call", StringComparison.OrdinalIgnoreCase));
    }
}
public class InteractionStreamEvent
{
    [JsonProperty("event_id")]
    public string EventId { get; set; } = "";
    [JsonProperty("event_type")]
    public string EventType { get; set; } = "";
    [JsonProperty("interaction")]
    public InteractionObject? Interaction { get; set; }
    [JsonProperty("interaction_id")]
    public string InteractionId { get; set; } = "";
    [JsonProperty("status")]
    public string Status { get; set; } = "";
    [JsonProperty("error")]
    public InteractionStreamError? Error { get; set; }
    [JsonProperty("index")]
    public int Index { get; set; }
    [JsonProperty("step")]
    public InteractionStep Step { get; set; } = new();
    [JsonProperty("delta")]
    public InteractionStreamDelta Delta { get; set; } = new();
}
public class InteractionStreamDelta : InteractionContent
{
    [JsonProperty("document_uri")]
    public string DocumentUri { get; set; } = "";
    [JsonProperty("start_index")]
    public int? StartIndex { get; set; }
    [JsonProperty("end_index")]
    public int? EndIndex { get; set; }
    [JsonProperty("page_number")]
    public int? PageNumber { get; set; }
    [JsonProperty("is_error")]
    public bool? IsError { get; set; }
    public int? Channels { get; set; }
    [JsonProperty("sample_rate")]
    public int? SampleRate { get; set; }
    public string Resolution { get; set; } = "";
    public JToken? Content { get; set; }
}
public class InteractionStreamError
{
    public string Code { get; set; } = "";
    public string Message { get; set; } = "";
}
internal static class InteractionsQueryString
{
    public static string Create(params (string Name, object? Value)[] values)
    {
        var l = new List<string>();
        foreach (var item in values)
        {
            if (item.Value == null) { continue; }
            var value = item.Value is bool b ? b.ToString().ToLowerInvariant() : item.Value.ToString();
            if (value.IsNullOrEmpty()) { continue; }
            l.Add($"{Uri.EscapeDataString(item.Name)}={Uri.EscapeDataString(value!)}");
        }
        return String.Join("&", l);
    }
}

public partial class GoogleAIClient
{
    public async ValueTask<InteractionsCreateResponse> InteractionsCreateAsync(InteractionsCreateParameter parameter)
    {
        return await this.InteractionsCreateAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<InteractionsCreateResponse> InteractionsCreateAsync(InteractionsCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<InteractionsCreateParameter, InteractionsCreateResponse>(parameter, cancellationToken);
    }
    public async ValueTask<InteractionsGetResponse> InteractionsGetAsync(InteractionsGetParameter parameter)
    {
        return await this.InteractionsGetAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<InteractionsGetResponse> InteractionsGetAsync(InteractionsGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<InteractionsGetParameter, InteractionsGetResponse>(parameter, cancellationToken);
    }
    public async ValueTask<InteractionsDeleteResponse> InteractionsDeleteAsync(InteractionsDeleteParameter parameter)
    {
        return await this.InteractionsDeleteAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<InteractionsDeleteResponse> InteractionsDeleteAsync(InteractionsDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<InteractionsDeleteParameter, InteractionsDeleteResponse>(parameter, cancellationToken);
    }
    public async ValueTask<InteractionsCancelResponse> InteractionsCancelAsync(InteractionsCancelParameter parameter)
    {
        return await this.InteractionsCancelAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<InteractionsCancelResponse> InteractionsCancelAsync(InteractionsCancelParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<InteractionsCancelParameter, InteractionsCancelResponse>(parameter, cancellationToken);
    }
    public async IAsyncEnumerable<string> InteractionsCreateStreamAsync(InteractionsCreateParameter parameter)
    {
        await foreach (var item in this.GetStreamAsync(parameter, null, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> InteractionsCreateStreamAsync(InteractionsCreateParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in this.GetStreamAsync(parameter, null, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> InteractionsCreateStreamAsync(InteractionsCreateParameter parameter, InteractionStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> InteractionsGetStreamAsync(InteractionsGetParameter parameter, InteractionStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<InteractionStreamEvent> GetInteractionStreamEventAsync(InteractionsCreateParameter parameter, InteractionStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var item in this.GetInteractionStreamEventAsync<InteractionsCreateParameter>(parameter, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<InteractionStreamEvent> GetInteractionStreamEventAsync(InteractionsGetParameter parameter, InteractionStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var item in this.GetInteractionStreamEventAsync<InteractionsGetParameter>(parameter, result, cancellationToken))
        {
            yield return item;
        }
    }
    private async IAsyncEnumerable<InteractionStreamEvent> GetInteractionStreamEventAsync<TParameter>(TParameter parameter, InteractionStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
        where TParameter : RestApiParameter, IRestApiParameter
    {
        var eventName = "";
        await foreach (var line in this.GetStreamAsync(parameter, cancellationToken))
        {
            if (line.IsEvent())
            {
                eventName = line.GetText();
            }
            if (line.IsData())
            {
                var text = line.GetText();
                if (string.Equals(text, "[DONE]", StringComparison.OrdinalIgnoreCase)) { continue; }

                var streamEvent = this.JsonConverter.DeserializeObject<InteractionStreamEvent>(text);
                if (streamEvent.EventType.IsNullOrEmpty())
                {
                    streamEvent.EventType = eventName;
                }
                result?.Process(streamEvent);
                yield return streamEvent;
            }
        }
    }
    public async IAsyncEnumerable<string> GetStreamAsync(InteractionsCreateParameter parameter, InteractionStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var streamEvent in this.GetInteractionStreamEventAsync(parameter, result, cancellationToken))
        {
            if (string.Equals(streamEvent.EventType, "step.delta", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(streamEvent.Delta.Type, "text", StringComparison.OrdinalIgnoreCase))
            {
                yield return streamEvent.Delta.Text;
            }
        }
    }
    public async IAsyncEnumerable<string> GetStreamAsync(InteractionsGetParameter parameter, InteractionStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var streamEvent in this.GetInteractionStreamEventAsync(parameter, result, cancellationToken))
        {
            if (string.Equals(streamEvent.EventType, "step.delta", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(streamEvent.Delta.Type, "text", StringComparison.OrdinalIgnoreCase))
            {
                yield return streamEvent.Delta.Text;
            }
        }
    }
}
