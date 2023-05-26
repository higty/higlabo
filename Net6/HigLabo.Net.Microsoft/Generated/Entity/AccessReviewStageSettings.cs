using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewstagesettings?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewStageSettings
    {
        public String[]? DecisionsThatWillMoveToNextStage { get; set; }
        public String[]? DependsOn { get; set; }
        public Int32? DurationInDays { get; set; }
        public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
        public bool? RecommendationsEnabled { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public string? StageId { get; set; }
    }
}
