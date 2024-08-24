using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudclipboarditem?view=graph-rest-1.0
    /// </summary>
    public partial class CloudClipboardItem
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public Guid? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public CloudClipboardItemPayload[]? Payloads { get; set; }
    }
}
