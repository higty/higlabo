using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/insights-resourcevisualization?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceVisualization
    {
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? MediaType { get; set; }
        public string? PreviewImageUrl { get; set; }
        public string? PreviewText { get; set; }
        public string? ContainerWebUrl { get; set; }
        public string? ContainerDisplayName { get; set; }
        public string? ContainerType { get; set; }
    }
}
