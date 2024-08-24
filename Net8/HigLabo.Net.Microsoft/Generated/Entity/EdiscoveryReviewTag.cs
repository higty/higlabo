using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoveryreviewtag?view=graph-rest-1.0
    /// </summary>
    public partial class EDiscoveryReviewTag
    {
        public enum EDiscoveryReviewTagSecurityChildSelectability
        {
            One,
            Many,
        }

        public EDiscoveryReviewTagSecurityChildSelectability ChildSelectability { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EDiscoveryReviewTag[]? ChildTags { get; set; }
        public EDiscoveryReviewTag? Parent { get; set; }
    }
}
