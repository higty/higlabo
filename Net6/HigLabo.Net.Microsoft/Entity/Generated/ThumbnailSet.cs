using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/thumbnailset?view=graph-rest-1.0
    /// </summary>
    public partial class ThumbnailSet
    {
        public string? Id { get; set; }
        public Thumbnail? Large { get; set; }
        public Thumbnail? Medium { get; set; }
        public Thumbnail? Small { get; set; }
        public Thumbnail? Source { get; set; }
    }
}
