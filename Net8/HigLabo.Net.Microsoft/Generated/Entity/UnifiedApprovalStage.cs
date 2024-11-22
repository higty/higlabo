using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/unifiedapprovalstage?view=graph-rest-1.0
/// </summary>
public partial class UnifiedApprovalStage
{
    public Int32? ApprovalStageTimeOutInDays { get; set; }
    public SubjectSet[]? EscalationApprovers { get; set; }
    public Int32? EscalationTimeInMinutes { get; set; }
    public bool? IsApproverJustificationRequired { get; set; }
    public bool? IsEscalationEnabled { get; set; }
    public SubjectSet[]? PrimaryApprovers { get; set; }
}
