using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/itemreference?view=graph-rest-1.0
    /// </summary>
    public partial class ItemReference
    {
        public string? DriveId { get; set; }
        public string? DriveType { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? ShareId { get; set; }
        public SharePointIds? SharepointIds { get; set; }
        public string? SiteId { get; set; }
    }
}
