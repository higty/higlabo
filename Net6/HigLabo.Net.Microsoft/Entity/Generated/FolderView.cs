using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/folderview?view=graph-rest-1.0
    /// </summary>
    public partial class FolderView
    {
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
        public string? ViewType { get; set; }
    }
}
