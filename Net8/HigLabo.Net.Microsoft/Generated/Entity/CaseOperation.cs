using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-caseoperation?view=graph-rest-1.0#caseaction-values
/// </summary>
public partial class CaseOperation
{
    public enum CaseOperationSecurityCaseAction
    {
        AddToReviewSet,
        ApplyTags,
        ContentExport,
        ConvertToPdf,
        EstimateStatistics,
        PurgeData,
    }
    public enum CaseOperationSecurityCaseOperationStatus
    {
        NotStarted,
        SubmissionFailed,
        Running,
        Succeeded,
        PartiallySucceeded,
        Failed,
    }

    public CaseOperationSecurityCaseAction Action { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public Int32? PercentProgress { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public CaseOperation? Status { get; set; }
}
