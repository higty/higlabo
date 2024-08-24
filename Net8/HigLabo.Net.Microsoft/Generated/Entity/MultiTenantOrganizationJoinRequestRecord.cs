using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/multitenantorganizationjoinrequestrecord?view=graph-rest-1.0
    /// </summary>
    public partial class MultiTenantOrganizationJoinRequestRecord
    {
        public enum MultiTenantOrganizationJoinRequestRecordMultiTenantOrganizationMemberState
        {
            Pending,
            Active,
            Removed,
            UnknownFutureValue,
        }
        public enum MultiTenantOrganizationJoinRequestRecordMultiTenantOrganizationMemberRole
        {
            Owner,
            Member,
            UnknownFutureValue,
        }

        public string? AddedByTenantId { get; set; }
        public MultiTenantOrganizationJoinRequestRecordMultiTenantOrganizationMemberState MemberState { get; set; }
        public MultiTenantOrganizationJoinRequestRecordMultiTenantOrganizationMemberRole Role { get; set; }
        public MultiTenantOrganizationJoinRequestTransitionDetails? TransitionDetails { get; set; }
    }
}
