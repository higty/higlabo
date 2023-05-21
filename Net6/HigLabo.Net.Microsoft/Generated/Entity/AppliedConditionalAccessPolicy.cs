using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/appliedconditionalaccesspolicy?view=graph-rest-1.0
    /// </summary>
    public partial class AppliedConditionalAccessPolicy
    {
        public enum AppliedConditionalAccessPolicyAppliedConditionalAccessPolicyResult
        {
            Success,
            Failure,
            NotApplied,
            NotEnabled,
            Unknown,
            UnknownFutureValue,
        }

        public string? DisplayName { get; set; }
        public String[]? EnforcedGrantControls { get; set; }
        public String[]? EnforcedSessionControls { get; set; }
        public string? Id { get; set; }
        public AppliedConditionalAccessPolicyAppliedConditionalAccessPolicyResult Result { get; set; }
    }
}
