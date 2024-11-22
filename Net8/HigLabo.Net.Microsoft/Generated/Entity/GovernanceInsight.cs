using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/governanceinsight?view=graph-rest-1.0
/// </summary>
public partial class GovernanceInsight
{
    public string? Id { get; set; }
    public DateTimeOffset? InsightCreatedDateTime { get; set; }
}
