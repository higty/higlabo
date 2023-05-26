using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chatmessagementionedidentityset?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageMentionedIdentitySet
    {
        public Identity? Application { get; set; }
        public TeamworkConversationIdentity? Conversation { get; set; }
        public Identity? Device { get; set; }
        public Identity? User { get; set; }
    }
}
