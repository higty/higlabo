using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/search-answerkeyword?view=graph-rest-1.0
/// </summary>
public partial class AnswerKeyword
{
    public String[]? Keywords { get; set; }
    public bool? MatchSimilarKeywords { get; set; }
    public String[]? ReservedKeywords { get; set; }
}
