using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthorizationPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            AllowedToSignUpEmailBasedSubscriptions,
            AllowedToUseSSPR,
            AllowEmailVerifiedUsersToJoinOrganization,
            AllowInvitesFrom,
            BlockMsolPowerShell,
            DefaultUserRolePermissions,
            Description,
            DisplayName,
            GuestUserRoleId,
            Id,
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class AuthorizationPolicyGetResponse : RestApiResponse
    {
        public enum AuthorizationPolicyAllowInvitesFrom
        {
            None,
            AdminsAndGuestInviters,
            AdminsGuestInvitersAndAllMembers,
            Everyone,
        }

        public bool? AllowedToSignUpEmailBasedSubscriptions { get; set; }
        public bool? AllowedToUseSSPR { get; set; }
        public bool? AllowEmailVerifiedUsersToJoinOrganization { get; set; }
        public AuthorizationPolicyAllowInvitesFrom AllowInvitesFrom { get; set; }
        public bool? BlockMsolPowerShell { get; set; }
        public DefaultUserRolePermissions? DefaultUserRolePermissions { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Guid? GuestUserRoleId { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyGetResponse> AuthorizationPolicyGetAsync()
        {
            var p = new AuthorizationPolicyGetParameter();
            return await this.SendAsync<AuthorizationPolicyGetParameter, AuthorizationPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyGetResponse> AuthorizationPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthorizationPolicyGetParameter();
            return await this.SendAsync<AuthorizationPolicyGetParameter, AuthorizationPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyGetResponse> AuthorizationPolicyGetAsync(AuthorizationPolicyGetParameter parameter)
        {
            return await this.SendAsync<AuthorizationPolicyGetParameter, AuthorizationPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationPolicyGetResponse> AuthorizationPolicyGetAsync(AuthorizationPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthorizationPolicyGetParameter, AuthorizationPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
