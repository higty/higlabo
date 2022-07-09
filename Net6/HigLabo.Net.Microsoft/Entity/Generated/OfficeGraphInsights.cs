using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/officegraphinsights?view=graph-rest-1.0
    /// </summary>
    public partial class OfficeGraphInsights
    {
        public Trending[]? Trending { get; set; }
        public UsedInsight[]? Used { get; set; }
        public SharedInsight[]? Shared { get; set; }
    }
}
