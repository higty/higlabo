using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessagereaction?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageReaction
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? ReactionType { get; set; }
        public ChatMessageReactionIdentitySet? User { get; set; }
    }
}
