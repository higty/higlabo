using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/searchhitscontainer?view=graph-rest-1.0
/// </summary>
public partial class SearchHitsContainer
{
    public SearchHit[]? Hits { get; set; }
    public bool? MoreResultsAvailable { get; set; }
    public Int32? Total { get; set; }
}
