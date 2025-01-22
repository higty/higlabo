using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/approvalsettings?view=graph-rest-1.0
/// </summary>
public partial class ApprovalSettings
{
    public string? ApprovalMode { get; set; }
    public UnifiedApprovalStage[]? ApprovalStages { get; set; }
    public bool? IsApprovalRequired { get; set; }
    public bool? IsApprovalRequiredForExtension { get; set; }
    public bool? IsRequestorJustificationRequired { get; set; }
}
