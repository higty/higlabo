using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityGovernance
    {
        public AccessReviewSet? AccessReviews { get; set; }
        public AppConsentApprovalRoute? AppConsent { get; set; }
        public EntitlementManagement? EntitlementManagement { get; set; }
        public TermsOfUseContainer? TermsOfUse { get; set; }
        public LifecycleWorkflowsContainer? LifecycleWorkflows { get; set; }
        public PrivilegedAccessRoot? PrivilegedAccess { get; set; }
    }
}
