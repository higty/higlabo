using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AuthorizationpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AuthorizationPolicy,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_AuthorizationPolicy: return $"/policies/authorizationPolicy";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class AuthorizationpolicyGetResponse : RestApiResponse
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
        public async Task<AuthorizationpolicyGetResponse> AuthorizationpolicyGetAsync()
        {
            var p = new AuthorizationpolicyGetParameter();
            return await this.SendAsync<AuthorizationpolicyGetParameter, AuthorizationpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationpolicyGetResponse> AuthorizationpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AuthorizationpolicyGetParameter();
            return await this.SendAsync<AuthorizationpolicyGetParameter, AuthorizationpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationpolicyGetResponse> AuthorizationpolicyGetAsync(AuthorizationpolicyGetParameter parameter)
        {
            return await this.SendAsync<AuthorizationpolicyGetParameter, AuthorizationpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/authorizationpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AuthorizationpolicyGetResponse> AuthorizationpolicyGetAsync(AuthorizationpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AuthorizationpolicyGetParameter, AuthorizationpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
