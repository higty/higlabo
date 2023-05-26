using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-alertcomment?view=graph-rest-1.0
    /// </summary>
    public partial class AlertComment
    {
        public string? Comment { get; set; }
        public string? CreatedByDisplayName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
}
