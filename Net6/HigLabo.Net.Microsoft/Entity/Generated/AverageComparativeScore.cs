using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/averagecomparativescore?view=graph-rest-1.0
    /// </summary>
    public partial class AverageComparativeScore
    {
        public string? Basis { get; set; }
        public Double? AverageScore { get; set; }
    }
}
