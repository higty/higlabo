using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/authorizationpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class AuthorizationPolicy
    {
        public bool AllowedToSignUpEmailBasedSubscriptions { get; set; }
        public bool AllowedToUseSSPR { get; set; }
        public bool AllowEmailVerifiedUsersToJoinOrganization { get; set; }
        public AuthorizationPolicyAllowInvitesFrom AllowInvitesFrom { get; set; }
        public bool BlockMsolPowerShell { get; set; }
        public DefaultUserRolePermissions? DefaultUserRolePermissions { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Guid? GuestUserRoleId { get; set; }
        public string Id { get; set; }
    }
}
