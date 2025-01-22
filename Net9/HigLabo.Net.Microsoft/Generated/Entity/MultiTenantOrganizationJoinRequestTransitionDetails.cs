using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/multitenantorganizationjoinrequesttransitiondetails?view=graph-rest-1.0
/// </summary>
public partial class MultiTenantOrganizationJoinRequestTransitionDetails
{
    public enum MultiTenantOrganizationJoinRequestTransitionDetailsMultiTenantOrganizationMemberState
    {
        Pending,
        Active,
        Removed,
        UnknownFutureValue,
    }
    public enum MultiTenantOrganizationJoinRequestTransitionDetailsMultiTenantOrganizationMemberProcessingStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public MultiTenantOrganizationJoinRequestTransitionDetailsMultiTenantOrganizationMemberState DesiredMemberState { get; set; }
    public string? Details { get; set; }
    public MultiTenantOrganizationJoinRequestTransitionDetailsMultiTenantOrganizationMemberProcessingStatus Status { get; set; }
}
