using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/retentionsetting?view=graph-rest-1.0
    /// </summary>
    public partial class RetentionSetting
    {
        public string? Interval { get; set; }
        public string? Period { get; set; }
    }
}
