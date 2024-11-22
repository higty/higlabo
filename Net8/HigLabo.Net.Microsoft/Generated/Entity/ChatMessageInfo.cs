using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/chatmessageinfo?view=graph-rest-1.0
/// </summary>
public partial class ChatMessageInfo
{
    public enum ChatMessageInfoChatMessageType
    {
        Message,
        UnknownFutureValue,
        SystemEventMessage,
    }

    public ItemBody? Body { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public EventMessageDetail? EventDetail { get; set; }
    public ChatMessageFromIdentitySet? From { get; set; }
    public string? Id { get; set; }
    public bool? IsDeleted { get; set; }
    public ChatMessageInfoChatMessageType MessageType { get; set; }
}
