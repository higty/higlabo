using HigLabo.Core;
using System.Text;

namespace HigLabo.Anthropic;

public class MessageContentBlockDelta
{
    public string Type { get; set; } = "";
    public int Index { get; set; }
    public string Data { get; set; } = "";
    public MessageContentBlockDeltaText Delta { get; set; } = new();

    public override string ToString()
    {
        return this.Delta.ToString();
    }
}
public class MessageContentBlockDeltaText
{
    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
    public string Partial_Json { get; set; } = "";
    public string Thinking { get; set; } = "";

    public override string ToString()
    {
        if (this.Text.IsNullOrEmpty() == false) { return this.Text; }
        if (this.Partial_Json.IsNullOrEmpty() == false) { return this.Partial_Json; }
        return this.Type;
    }
}
