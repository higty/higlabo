using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/mediainfo?view=graph-rest-1.0
    /// </summary>
    public partial class MediaInfo
    {
        public string? ResourceId { get; set; }
        public string? Uri { get; set; }
    }
}
