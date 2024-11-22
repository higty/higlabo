using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/conversation?view=graph-rest-1.0
/// </summary>
public partial class Conversation
{
    public bool? HasAttachments { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastDeliveredDateTime { get; set; }
    public string? Preview { get; set; }
    public string? Topic { get; set; }
    public String[]? UniqueSenders { get; set; }
    public ConversationThread[]? Threads { get; set; }
}
