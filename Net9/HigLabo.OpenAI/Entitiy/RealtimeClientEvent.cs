namespace HigLabo.OpenAI;

public class RealtimeResponseCreateClientEvent
{
    public string Type { get; set; } = "response.create";
}

public class RealtimeSessionUpdateClientEvent
{
    public string Type { get; set; } = "session.update";
    public RealtimeSessionUpdateData Session { get; set; } = new();
}

public class RealtimeSessionUpdateData
{
    public string Type { get; set; } = "realtime";
    public List<FunctionTool> Tools { get; set; } = new();
    public string Tool_Choice { get; set; } = "auto";
    public RealtimeAudioConfig? Audio { get; set; }
}

public class RealtimeConversationItemCreateClientEvent
{
    public string Type { get; set; } = "conversation.item.create";
    public RealtimeConversationItem Item { get; set; } = new();
}

public class RealtimeConversationItem
{
    public string Type { get; set; } = "";
    public string Call_Id { get; set; } = "";
    public string Output { get; set; } = "";
}
