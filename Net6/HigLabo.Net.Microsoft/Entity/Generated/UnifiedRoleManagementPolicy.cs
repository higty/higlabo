using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedrolemanagementpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedRoleManagementPolicy
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public Identity? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? ScopeId { get; set; }
        public string? ScopeType { get; set; }
    }
}
