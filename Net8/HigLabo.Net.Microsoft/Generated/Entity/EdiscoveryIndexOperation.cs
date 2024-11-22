using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoveryindexoperation?view=graph-rest-1.0
/// </summary>
public partial class EDiscoveryIndexOperation
{
    public enum EDiscoveryIndexOperationSecurityCaseAction
    {
        AddToReviewSet,
        ApplyTags,
        ContentExport,
        ConvertToPdf,
        EstimateStatistics,
        PurgeData,
    }
    public enum EDiscoveryIndexOperationSecurityCaseOperationStatus
    {
        NotStarted,
        SubmissionFailed,
        Running,
        Succeeded,
        PartiallySucceeded,
        Failed,
    }

    public CaseOperation? Action { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Int32? PercentProgress { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public EDiscoveryIndexOperationSecurityCaseOperationStatus Status { get; set; }
}
