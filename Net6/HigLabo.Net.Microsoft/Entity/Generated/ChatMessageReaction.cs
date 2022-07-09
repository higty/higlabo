using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessagereaction?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageReAction
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? ReactionType { get; set; }
        public ChatMessageReActionIdentitySet? User { get; set; }
    }
}
