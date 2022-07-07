using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/uploadsession?view=graph-rest-1.0
    /// </summary>
    public partial class UploadSession
    {
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
}
