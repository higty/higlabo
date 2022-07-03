using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/projectrome-activity?view=graph-rest-1.0
    /// </summary>
    public partial class Activity
    {
        public string UserTimezone { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string Id { get; set; }
        public string AppActivityId { get; set; }
        public string ActivitySourceHost { get; set; }
        public string AppDisplayName { get; set; }
        public string ActivationUrl { get; set; }
        public string FallbackUrl { get; set; }
        public string ContentUrl { get; set; }
        public VisualInfo? VisualElements { get; set; }
        public object ContentInfo { get; set; }
        public DateTimeOffset ExpirationDateTime { get; set; }
        public Status? Status { get; set; }
    }
}
