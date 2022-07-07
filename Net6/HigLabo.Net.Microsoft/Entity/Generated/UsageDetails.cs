using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/insights-usagedetails?view=graph-rest-1.0
    /// </summary>
    public partial class UsageDetails
    {
        public DateTimeOffset? LastAccessedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
}
