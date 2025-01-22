using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/chatinfo?view=graph-rest-1.0
/// </summary>
public partial class ChatInfo
{
    public string? MessageId { get; set; }
    public string? ReplyChainMessageId { get; set; }
    public string? ThreadId { get; set; }
}
