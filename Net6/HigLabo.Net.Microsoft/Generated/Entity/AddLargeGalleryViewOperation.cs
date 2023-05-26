using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/addlargegalleryviewoperation?view=graph-rest-1.0
    /// </summary>
    public partial class AddLargeGalleryViewOperation
    {
        public enum AddLargeGalleryViewOperationOperationStatus
        {
            NotStarted,
            Running,
            Completed,
            Failed,
        }

        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public AddLargeGalleryViewOperationOperationStatus Status { get; set; }
    }
}
