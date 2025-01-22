using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewstage?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewStage
{
    public DateTimeOffset? EndDateTime { get; set; }
    public AccessReviewReviewerScope[]? FallbackReviewers { get; set; }
    public string? Id { get; set; }
    public AccessReviewReviewerScope[]? Reviewers { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? Status { get; set; }
    public AccessReviewInstanceDecisionItem[]? Decisions { get; set; }
}
