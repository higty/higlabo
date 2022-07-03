using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/site?view=graph-rest-1.0
    /// </summary>
    public partial class Site
    {
        public String? Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public String? Description { get; set; }
        public String? DisplayName { get; set; }
        public String? ETag { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public String? Name { get; set; }
        public Root? Root { get; set; }
        public SharePointIds SharepointIds { get; set; }
        public SiteCollection? SiteCollection { get; set; }
        public string WebUrl { get; set; }
    }
}
