using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/recentnotebook?view=graph-rest-1.0
    /// </summary>
    public partial class RecentNotebook
    {
        public enum RecentNotebookOnenoteSourceService
        {
            OneDriveForBusiness,
            OneDrive,
        }

        public string? DisplayName { get; set; }
        public DateTimeOffset? LastAccessedTime { get; set; }
        public RecentNotebookLinks? Links { get; set; }
        public RecentNotebookOnenoteSourceService SourceService { get; set; }
    }
}
