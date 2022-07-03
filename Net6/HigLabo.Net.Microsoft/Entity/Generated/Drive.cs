using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/drive?view=graph-rest-1.0
    /// </summary>
    public partial class Drive
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string DriveType { get; set; }
        public string Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public String? Name { get; set; }
        public IdentitySet? Owner { get; set; }
        public Quota? Quota { get; set; }
        public SharePointIds SharepointIds { get; set; }
        public SystemFacet? System { get; set; }
        public string WebUrl { get; set; }
    }
}
