using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/insights-trending?view=graph-rest-1.0
/// </summary>
public partial class Trending
{
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public ResourceReference? ResourceReference { get; set; }
    public ResourceVisualization? ResourceVisualization { get; set; }
    public Double? Weight { get; set; }
    public Entity? Resource { get; set; }
}
