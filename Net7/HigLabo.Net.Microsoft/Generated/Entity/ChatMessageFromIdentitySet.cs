using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chatmessagefromidentityset?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageFromIdentitySet
    {
        public Identity? Application { get; set; }
        public Identity? Device { get; set; }
        public TeamworkUserIdentity? User { get; set; }
    }
}
