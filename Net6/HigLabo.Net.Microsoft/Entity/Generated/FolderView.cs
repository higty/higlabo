using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/folderview?view=graph-rest-1.0
    /// </summary>
    public partial class FolderView
    {
        public String? SortBy { get; set; }
        public String? SortOrder { get; set; }
        public String? ViewType { get; set; }
    }
}
