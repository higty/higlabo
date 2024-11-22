using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/searchalteration?view=graph-rest-1.0
/// </summary>
public partial class SearchAlteration
{
    public string? AlteredHighlightedQueryString { get; set; }
    public string? AlteredQueryString { get; set; }
    public AlteredQueryToken[]? AlteredQueryTokens { get; set; }
}
