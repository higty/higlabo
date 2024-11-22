namespace HigLabo.Anthropic;

public class MessageStart
{
    public string Type { get; set; } = "";
    public MessagesObject Message { get; set; } = new();
}
