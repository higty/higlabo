using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/averagecomparativescore?view=graph-rest-1.0
/// </summary>
public partial class AverageComparativeScore
{
    public Double? AverageScore { get; set; }
    public string? Basis { get; set; }
}
