using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/officegraphinsights?view=graph-rest-1.0
/// </summary>
public partial class OfficeGraphInsights
{
    public SharedInsight[]? Shared { get; set; }
    public Trending[]? Trending { get; set; }
    public UsedInsight[]? Used { get; set; }
}
