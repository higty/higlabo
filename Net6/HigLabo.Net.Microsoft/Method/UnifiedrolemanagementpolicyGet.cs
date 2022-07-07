using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedrolemanagementpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId: return $"/policies/roleManagementPolicies/{UnifiedRoleManagementPolicyId}";
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
        public string UnifiedRoleManagementPolicyId { get; set; }
    }
    public partial class UnifiedrolemanagementpolicyGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyGetResponse> UnifiedrolemanagementpolicyGetAsync()
        {
            var p = new UnifiedrolemanagementpolicyGetParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyGetParameter, UnifiedrolemanagementpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyGetResponse> UnifiedrolemanagementpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedrolemanagementpolicyGetParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyGetParameter, UnifiedrolemanagementpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyGetResponse> UnifiedrolemanagementpolicyGetAsync(UnifiedrolemanagementpolicyGetParameter parameter)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyGetParameter, UnifiedrolemanagementpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyGetResponse> UnifiedrolemanagementpolicyGetAsync(UnifiedrolemanagementpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyGetParameter, UnifiedrolemanagementpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
