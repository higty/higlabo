using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/post?view=graph-rest-1.0
    /// </summary>
    public partial class Post
    {
        public ItemBody? Body { get; set; }
        public String[] Categories { get; set; }
        public string ChangeKey { get; set; }
        public string ConversationId { get; set; }
        public string ConversationThreadId { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public Recipient? From { get; set; }
        public bool HasAttachments { get; set; }
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public Recipient[] NewParticipants { get; set; }
        public DateTimeOffset ReceivedDateTime { get; set; }
        public Recipient? Sender { get; set; }
    }
}
