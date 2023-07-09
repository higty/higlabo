using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ocrsettings?view=graph-rest-1.0
    /// </summary>
    public partial class OcrSettings
    {
        public bool? IsEnabled { get; set; }
        public Int32? MaxImageSize { get; set; }
        public string? Timeout { get; set; }
    }
}
