using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sharepointids?view=graph-rest-1.0
    /// </summary>
    public partial class SharePointIds
    {
        public string? ListId { get; set; }
        public string? ListItemId { get; set; }
        public string? ListItemUniqueId { get; set; }
        public string? SiteId { get; set; }
        public string? SiteUrl { get; set; }
        public string? TenantId { get; set; }
        public string? WebId { get; set; }
    }
}
