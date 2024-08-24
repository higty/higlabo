using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/multitenantorganizationmember?view=graph-rest-1.0
    /// </summary>
    public partial class MultiTenantOrganizationMember
    {
        public enum MultiTenantOrganizationMemberMultiTenantOrganizationMemberRole
        {
            Owner,
            Member,
            UnknownFutureValue,
        }
        public enum MultiTenantOrganizationMemberMultiTenantOrganizationMemberState
        {
            Pending,
            Active,
            Removed,
            UnknownFutureValue,
        }

        public string? AddedByTenantId { get; set; }
        public DateTimeOffset? AddedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? JoinedDateTime { get; set; }
        public MultiTenantOrganizationMemberMultiTenantOrganizationMemberRole Role { get; set; }
        public MultiTenantOrganizationMemberMultiTenantOrganizationMemberState State { get; set; }
        public string? TenantId { get; set; }
        public MultiTenantOrganizationMemberTransitionDetails? TransitionDetails { get; set; }
    }
}
