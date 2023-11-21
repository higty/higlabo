using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/recommendedaction?view=graph-rest-1.0
    /// </summary>
    public partial class RecommendedAction
    {
        public string? ActionWebUrl { get; set; }
        public Double? PotentialScoreImpact { get; set; }
        public string? Title { get; set; }
    }
}
