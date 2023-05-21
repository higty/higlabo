using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-mailclusterevidence?view=graph-rest-1.0
    /// </summary>
    public partial class MailClusterEvidence
    {
        public string? ClusterBy { get; set; }
        public string? ClusterByValue { get; set; }
        public Int64? EmailCount { get; set; }
        public String[]? NetworkMessageIds { get; set; }
        public string? Query { get; set; }
        public string? Urn { get; set; }
    }
}
