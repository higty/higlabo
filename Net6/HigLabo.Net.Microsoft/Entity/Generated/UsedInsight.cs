using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/insights-used?view=graph-rest-1.0
    /// </summary>
    public partial class UsedInsight
    {
        public string Id { get; set; }
        public UsageDetails? LastUsed { get; set; }
        public ResourceVisualization? ResourceVisualization { get; set; }
        public ResourceReference? ResourceReference { get; set; }
    }
}
