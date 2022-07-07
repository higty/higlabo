using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/mediastream?view=graph-rest-1.0
    /// </summary>
    public partial class MediaStream
    {
        public string? Direction { get; set; }
        public string? Label { get; set; }
        public string? MediaType { get; set; }
        public bool? ServerMuted { get; set; }
        public string? SourceId { get; set; }
    }
}
