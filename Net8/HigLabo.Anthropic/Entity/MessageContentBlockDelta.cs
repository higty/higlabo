namespace HigLabo.Anthropic;

public class MessageContentBlockDelta
{
    public string Type { get; set; } = "";
    public int Index { get; set; }
    public string Data { get; set; } = "";
    public MessageContentBlockDeltaText Delta { get; set; } = new();
}
public class MessageContentBlockDeltaText
{
    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
}
