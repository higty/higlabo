using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Anthropic;

public class MessagesStreamResult
{
    public MessagesObject? Message { get; set; }
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
}
