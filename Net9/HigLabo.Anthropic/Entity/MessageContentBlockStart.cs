namespace HigLabo.Anthropic;

public class MessageContentBlockStart
{
    public string Type { get; set; } = "";
    public int Index { get; set; }
    public MessageContentBlock Content_Block { get; set; } = new();
}
public class MessageContentBlock
{
    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
    public string? Id { get; set; }
    public string? Name { get; set; }
    public object? Input { get; set; }
}
