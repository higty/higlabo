using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoveryaddtoreviewsetoperation?view=graph-rest-1.0
/// </summary>
public partial class EDiscoveryAddToReviewSetOperation
{
    public enum EDiscoveryAddToReviewSetOperationSecurityCaseAction
    {
        AddToReviewSet,
        ApplyTags,
        ContentExport,
        ConvertToPdf,
        EstimateStatistics,
        PurgeData,
    }
    public enum EDiscoveryAddToReviewSetOperationSecurityCaseOperationStatus
    {
        NotStarted,
        SubmissionFailed,
        Running,
        Succeeded,
        PartiallySucceeded,
        Failed,
    }

    public EDiscoveryAddToReviewSetOperationSecurityCaseAction Action { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Int32? PercentProgress { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public EDiscoveryAddToReviewSetOperationSecurityCaseOperationStatus Status { get; set; }
    public EDiscoveryReviewSet? ReviewSet { get; set; }
    public EDiscoverySearch? Search { get; set; }
}
