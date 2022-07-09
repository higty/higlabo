using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/projectrome-visualinfo?view=graph-rest-1.0
    /// </summary>
    public partial class VisualInfo
    {
        public string? DisplayText { get; set; }
        public string? Description { get; set; }
        public string? BackgroundColor { get; set; }
        public object? Content { get; set; }
        public ImageInfo? Attribution { get; set; }
    }
}
