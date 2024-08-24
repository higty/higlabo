using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/multitenantorganizationmembertransitiondetails?view=graph-rest-1.0
    /// </summary>
    public partial class MultiTenantOrganizationMemberTransitionDetails
    {
        public enum MultiTenantOrganizationMemberTransitionDetailsMultiTenantOrganizationMemberRole
        {
            Owner,
            Member,
            UnknownFutureValue,
        }
        public enum MultiTenantOrganizationMemberTransitionDetailsMultiTenantOrganizationMemberState
        {
            Pending,
            Active,
            Removed,
            UnknownFutureValue,
        }
        public enum MultiTenantOrganizationMemberTransitionDetailsMultiTenantOrganizationMemberProcessingStatus
        {
            NotStarted,
            Running,
            Succeeded,
            Failed,
            UnknownFutureValue,
        }

        public MultiTenantOrganizationMemberTransitionDetailsMultiTenantOrganizationMemberRole DesiredRole { get; set; }
        public MultiTenantOrganizationMemberTransitionDetailsMultiTenantOrganizationMemberState DesiredState { get; set; }
        public string? Details { get; set; }
        public MultiTenantOrganizationMemberTransitionDetailsMultiTenantOrganizationMemberProcessingStatus Status { get; set; }
    }
}
