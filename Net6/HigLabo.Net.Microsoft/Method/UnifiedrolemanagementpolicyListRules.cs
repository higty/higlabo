using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedrolemanagementpolicyListRulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules: return $"/policies/roleManagementPolicies/{UnifiedRoleManagementPolicyId}/rules";
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
    public partial class UnifiedrolemanagementpolicyListRulesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedrolemanagementpolicyrule?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleManagementPolicyRule
        {
            public string? Id { get; set; }
            public UnifiedRoleManagementPolicyRuleTarget? Target { get; set; }
        }

        public UnifiedRoleManagementPolicyRule[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyListRulesResponse> UnifiedrolemanagementpolicyListRulesAsync()
        {
            var p = new UnifiedrolemanagementpolicyListRulesParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyListRulesParameter, UnifiedrolemanagementpolicyListRulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyListRulesResponse> UnifiedrolemanagementpolicyListRulesAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedrolemanagementpolicyListRulesParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyListRulesParameter, UnifiedrolemanagementpolicyListRulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyListRulesResponse> UnifiedrolemanagementpolicyListRulesAsync(UnifiedrolemanagementpolicyListRulesParameter parameter)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyListRulesParameter, UnifiedrolemanagementpolicyListRulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyListRulesResponse> UnifiedrolemanagementpolicyListRulesAsync(UnifiedrolemanagementpolicyListRulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyListRulesParameter, UnifiedrolemanagementpolicyListRulesResponse>(parameter, cancellationToken);
        }
    }
}
