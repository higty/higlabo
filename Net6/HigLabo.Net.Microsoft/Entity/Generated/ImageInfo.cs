using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/projectrome-imageinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ImageInfo
    {
        public string? IconUrl { get; set; }
        public string? AlternateText { get; set; }
        public bool? AddImageQuery { get; set; }
    }
}
