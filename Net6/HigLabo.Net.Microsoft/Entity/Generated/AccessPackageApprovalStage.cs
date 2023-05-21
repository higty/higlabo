using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageapprovalstage?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageApprovalStage
    {
        public string? DurationBeforeAutomaticDenial { get; set; }
        public string? DurationBeforeEscalation { get; set; }
        public SubjectSet[]? EscalationApprovers { get; set; }
        public SubjectSet[]? FallbackEscalationApprovers { get; set; }
        public SubjectSet[]? FallbackPrimaryApprovers { get; set; }
        public bool? IsApproverJustificationRequired { get; set; }
        public bool? IsEscalationEnabled { get; set; }
        public SubjectSet[]? PrimaryApprovers { get; set; }
    }
}
