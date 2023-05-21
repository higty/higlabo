using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/projectrome-visualinfo?view=graph-rest-1.0
    /// </summary>
    public partial class VisualInfo
    {
        public ImageInfo? Attribution { get; set; }
        public string? BackgroundColor { get; set; }
        public object? Content { get; set; }
        public string? Description { get; set; }
        public string? DisplayText { get; set; }
    }
}
