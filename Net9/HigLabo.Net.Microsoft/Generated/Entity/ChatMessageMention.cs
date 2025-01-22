using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/chatmessagemention?view=graph-rest-1.0
/// </summary>
public partial class ChatMessageMention
{
    public Int32? Id { get; set; }
    public ChatMessageMentionedIdentitySet? Mentioned { get; set; }
    public string? MentionText { get; set; }
}
