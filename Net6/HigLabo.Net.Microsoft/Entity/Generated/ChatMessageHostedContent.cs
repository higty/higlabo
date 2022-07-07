using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessagehostedcontent?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessageHostedContent
    {
        public string? Id { get; set; }
        public string? ContentBytes { get; set; }
        public string? ContentType { get; set; }
    }
}
