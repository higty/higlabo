using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewinstance?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewInstance
{
    public DateTimeOffset? EndDateTime { get; set; }
    public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
    public string? Id { get; set; }
    public AccessReviewReviewerScope[]? Reviewers { get; set; }
    public AccessReviewScope? Scope { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? Status { get; set; }
    public AccessReviewReviewer[]? ContactedReviewers { get; set; }
    public AccessReviewInstanceDecisionItem[]? Decisions { get; set; }
    public AccessReviewStage[]? Stages { get; set; }
}
