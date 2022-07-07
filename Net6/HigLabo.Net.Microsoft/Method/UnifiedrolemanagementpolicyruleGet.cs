using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedrolemanagementpolicyruleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules_UnifiedRoleManagementPolicyRuleId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules_UnifiedRoleManagementPolicyRuleId: return $"/policies/roleManagementPolicies/{UnifiedRoleManagementPolicyId}/rules/{UnifiedRoleManagementPolicyRuleId}";
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
        public string UnifiedRoleManagementPolicyRuleId { get; set; }
    }
    public partial class UnifiedrolemanagementpolicyruleGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public UnifiedRoleManagementPolicyRuleTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyruleGetResponse> UnifiedrolemanagementpolicyruleGetAsync()
        {
            var p = new UnifiedrolemanagementpolicyruleGetParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyruleGetParameter, UnifiedrolemanagementpolicyruleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyruleGetResponse> UnifiedrolemanagementpolicyruleGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedrolemanagementpolicyruleGetParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyruleGetParameter, UnifiedrolemanagementpolicyruleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyruleGetResponse> UnifiedrolemanagementpolicyruleGetAsync(UnifiedrolemanagementpolicyruleGetParameter parameter)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyruleGetParameter, UnifiedrolemanagementpolicyruleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyruleGetResponse> UnifiedrolemanagementpolicyruleGetAsync(UnifiedrolemanagementpolicyruleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyruleGetParameter, UnifiedrolemanagementpolicyruleGetResponse>(parameter, cancellationToken);
        }
    }
}
