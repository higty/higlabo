using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/verifiedpublisher?view=graph-rest-1.0
    /// </summary>
    public partial class VerifiedPublisher
    {
        public DateTimeOffset? AddedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? VerifiedPublisherId { get; set; }
    }
}
