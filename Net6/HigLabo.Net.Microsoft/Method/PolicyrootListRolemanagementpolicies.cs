using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PolicyrootListRolemanagementpoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_RoleManagementPolicies: return $"/policies/roleManagementPolicies";
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
    public partial class PolicyrootListRolemanagementpoliciesResponse : RestApiResponse
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

        public UnifiedRoleManagementPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpoliciesResponse> PolicyrootListRolemanagementpoliciesAsync()
        {
            var p = new PolicyrootListRolemanagementpoliciesParameter();
            return await this.SendAsync<PolicyrootListRolemanagementpoliciesParameter, PolicyrootListRolemanagementpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpoliciesResponse> PolicyrootListRolemanagementpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new PolicyrootListRolemanagementpoliciesParameter();
            return await this.SendAsync<PolicyrootListRolemanagementpoliciesParameter, PolicyrootListRolemanagementpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpoliciesResponse> PolicyrootListRolemanagementpoliciesAsync(PolicyrootListRolemanagementpoliciesParameter parameter)
        {
            return await this.SendAsync<PolicyrootListRolemanagementpoliciesParameter, PolicyrootListRolemanagementpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpoliciesResponse> PolicyrootListRolemanagementpoliciesAsync(PolicyrootListRolemanagementpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PolicyrootListRolemanagementpoliciesParameter, PolicyrootListRolemanagementpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
