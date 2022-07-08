using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthorizationPolicyUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthorizationPolicy: return $"/policies/authorizationPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AuthorizationPolicyUpdateParameterAllowInvitesFrom
        {
            None,
            AdminsAndGuestInviters,
            AdminsGuestInvitersAndAllMembers,
            Everyone,
        }
        public enum ApiPath
        {
            Policies_AuthorizationPolicy,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public bool? AllowedToSignUpEmailBasedSubscriptions { get; set; }
        public bool? AllowedToUseSSPR { get; set; }
        public bool? AllowEmailVerifiedUsersToJoinOrganization { get; set; }
        public AuthorizationPolicyUpdateParameterAllowInvitesFrom AllowInvitesFrom { get; set; }
        public bool? BlockMsolPowerShell { get; set; }
        public DefaultUserRolePermissions? DefaultUserRolePermissions { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Guid? GuestUserRoleId { get; set; }
    }
    public partial class AuthorizationPolicyUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyUpdateResponse> AuthorizationPolicyUpdateAsync()
        {
            var p = new AuthorizationPolicyUpdateParameter();
            return await this.SendAsync<AuthorizationPolicyUpdateParameter, AuthorizationPolicyUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyUpdateResponse> AuthorizationPolicyUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AuthorizationPolicyUpdateParameter();
            return await this.SendAsync<AuthorizationPolicyUpdateParameter, AuthorizationPolicyUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyUpdateResponse> AuthorizationPolicyUpdateAsync(AuthorizationPolicyUpdateParameter parameter)
        {
            return await this.SendAsync<AuthorizationPolicyUpdateParameter, AuthorizationPolicyUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyUpdateResponse> AuthorizationPolicyUpdateAsync(AuthorizationPolicyUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthorizationPolicyUpdateParameter, AuthorizationPolicyUpdateResponse>(parameter, cancellationToken);
        }
    }
}
