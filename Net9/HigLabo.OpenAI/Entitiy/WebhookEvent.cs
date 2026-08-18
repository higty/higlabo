namespace HigLabo.OpenAI;

public class WebhookEvent
{
    public string Type { get; set; } = "";
    public WebhookEventData? Data { get; set; }
}

public class WebhookEventData
{
    public string Call_Id { get; set; } = "";
    public List<SipHeader> Sip_Headers { get; set; } = new();
}

public class SipHeader
{
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
}
