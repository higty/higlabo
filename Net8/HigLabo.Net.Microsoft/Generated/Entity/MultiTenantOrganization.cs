using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/multitenantorganization?view=graph-rest-1.0
    /// </summary>
    public partial class MultiTenantOrganization
    {
        public enum MultiTenantOrganizationMultiTenantOrganizationState
        {
            Active,
            Inactive,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public MultiTenantOrganizationMultiTenantOrganizationState State { get; set; }
        public MultiTenantOrganizationJoinRequestRecord? JoinRequest { get; set; }
        public MultiTenantOrganizationMember[]? Tenants { get; set; }
    }
}
