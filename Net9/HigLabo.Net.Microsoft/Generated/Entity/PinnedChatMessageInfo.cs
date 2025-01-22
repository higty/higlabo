using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/pinnedchatmessageinfo?view=graph-rest-1.0
/// </summary>
public partial class PinnedChatMessageInfo
{
    public string? Id { get; set; }
    public ChatMessage? Message { get; set; }
}
