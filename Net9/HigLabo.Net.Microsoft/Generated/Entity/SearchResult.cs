using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/searchresult?view=graph-rest-1.0
/// </summary>
public partial class SearchResult
{
    public string? OnClickTelemetryUrl { get; set; }
}
