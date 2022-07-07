using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sharepointidentity?view=graph-rest-1.0
    /// </summary>
    public partial class SharePointIdentity
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? LoginName { get; set; }
        public ThumbnailSet[]? Thumbnails { get; set; }
    }
}
