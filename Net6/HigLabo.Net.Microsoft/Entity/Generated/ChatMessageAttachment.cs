using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessageattachment?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageAttachment
    {
        public String? Id { get; set; }
        public String? ContentType { get; set; }
        public String? ContentUrl { get; set; }
        public String? Content { get; set; }
        public String? Name { get; set; }
        public String? ThumbnailUrl { get; set; }
    }
}
