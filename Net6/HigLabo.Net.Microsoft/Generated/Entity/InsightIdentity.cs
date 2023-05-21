using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/insights-insightidentity?view=graph-rest-1.0
    /// </summary>
    public partial class InsightIdentity
    {
        public string? Address { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
}
