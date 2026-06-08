using HigLabo.Core;
using Newtonsoft.Json.Linq;
using System.Text;

namespace HigLabo.Anthropic;

public class MessagesStreamResult
{
    public List<MessagesStreamEvent> EventList { get; init; } = new();
    public MessagesObject? Message { get; set; }
    public List<MessageContentBlockStart> ContentBlockStartList { get; init; } = new();
    public List<MessageContentBlockDelta> DeltaList { get; init; } = new();
    public MessageDelta? MessageDelta { get; set; }

    public void Process(MessageContentBlockDelta delta)
    {
        this.DeltaList.Add(delta);
    }
    public string GetText()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < this.DeltaList.Count; i++)
        {
            var delta = this.DeltaList[i].Delta;
            if (string.Equals(delta.Type, "text_delta", StringComparison.OrdinalIgnoreCase))
            {
                sb.Append(delta.Text);
            }
        }
        return sb.ToString();
    }
    public string GetThinking()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < this.DeltaList.Count; i++)
        {
            var delta = this.DeltaList[i].Delta;
            if (string.Equals(delta.Type, "thinking_delta", StringComparison.OrdinalIgnoreCase))
            {
                sb.Append(delta.Thinking);
            }
        }
        return sb.ToString();
    }
    public string GetInputJson()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < this.DeltaList.Count; i++)
        {
            var delta = this.DeltaList[i].Delta;
            if (string.Equals(delta.Type, "input_json_delta", StringComparison.OrdinalIgnoreCase))
            {
                sb.Append(delta.Partial_Json);
            }
        }
        return sb.ToString();
    }
    public string GetStopReason()
    {
        return this.MessageDelta?.Delta?.Stop_Reason ?? "";
    }
    public MessageUsage? GetUsageResult()
    {
        if (this.Message == null && this.MessageDelta == null) { return null; }

        var usage = new MessageUsage();
        if (this.Message != null)
        {
            usage.Input_Tokens = this.Message.Usage.Input_Tokens;
            usage.Cache_Creation_Input_Tokens = this.Message.Usage.Cache_Creation_Input_Tokens;
            usage.Cache_Read_Input_Tokens = this.Message.Usage.Cache_Read_Input_Tokens;
            usage.Cache_Creation.Ephemeral_5m_Input_Tokens = this.Message.Usage.Cache_Creation.Ephemeral_5m_Input_Tokens;
            usage.Cache_Creation.Ephemeral_1h_Input_Tokens = this.Message.Usage.Cache_Creation.Ephemeral_1h_Input_Tokens;
            usage.Output_Tokens = this.Message.Usage.Output_Tokens;
        }
        if (this.MessageDelta != null)
        {
            usage.Output_Tokens = this.MessageDelta.Usage.Output_Tokens;
        }
        return usage;
    }
    public FunctionCallResult? GetFunctionCall()
    {
        return this.GetFunctionCallList().FirstOrDefault();
    }
    public List<FunctionCallResult> GetFunctionCallList()
    {
        var l = new List<FunctionCallResult>();
        foreach (var block in this.ContentBlockStartList.Where(el => string.Equals(el.Content_Block.Type, "tool_use", StringComparison.OrdinalIgnoreCase)))
        {
            var json = new StringBuilder();
            foreach (var delta in this.DeltaList.Where(el => el.Index == block.Index && string.Equals(el.Delta.Type, "input_json_delta", StringComparison.OrdinalIgnoreCase)))
            {
                json.Append(delta.Delta.Partial_Json);
            }
            var arguments = json.ToString();
            if (arguments.IsNullOrWhiteSpace() && block.Content_Block.Input != null)
            {
                arguments = global::Newtonsoft.Json.JsonConvert.SerializeObject(block.Content_Block.Input);
            }
            l.Add(new FunctionCallResult
            {
                Name = block.Content_Block.Name ?? "",
                Arguments = NormalizeJson(arguments),
            });
        }
        return l;
    }
    private static string NormalizeJson(string json)
    {
        if (string.IsNullOrWhiteSpace(json)) { return ""; }
        var token = JToken.Parse(json);
        return token.ToString(global::Newtonsoft.Json.Formatting.None);
    }
}
public class MessagesStreamEvent
{
    public string EventName { get; set; } = "";
    public string Data { get; set; } = "";
}
