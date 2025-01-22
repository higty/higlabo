using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/chatviewpoint?view=graph-rest-1.0
/// </summary>
public partial class ChatViewpoint
{
    public bool? IsHidden { get; set; }
    public DateTimeOffset? LastMessageReadDateTime { get; set; }
}
