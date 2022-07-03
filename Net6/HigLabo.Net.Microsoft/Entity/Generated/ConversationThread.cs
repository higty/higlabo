using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/conversationthread?view=graph-rest-1.0
    /// </summary>
    public partial class ConversationThread
    {
        public string Id { get; set; }
        public Recipient[] ToRecipients { get; set; }
        public Recipient[] CcRecipients { get; set; }
        public string Topic { get; set; }
        public bool HasAttachments { get; set; }
        public DateTimeOffset LastDeliveredDateTime { get; set; }
        public String[] UniqueSenders { get; set; }
        public string Preview { get; set; }
        public bool IsLocked { get; set; }
    }
}
