using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/documentsetversionitem?view=graph-rest-1.0
    /// </summary>
    public partial class DocumentSetVersionItem
    {
        public string? ItemId { get; set; }
        public string? Title { get; set; }
        public string? VersionId { get; set; }
    }
}
