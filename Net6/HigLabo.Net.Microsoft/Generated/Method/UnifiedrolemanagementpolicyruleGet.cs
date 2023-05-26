using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleManagementPolicyruleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UnifiedRoleManagementPolicyId { get; set; }
            public string? UnifiedRoleManagementPolicyRuleId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules_UnifiedRoleManagementPolicyRuleId: return $"/policies/roleManagementPolicies/{UnifiedRoleManagementPolicyId}/rules/{UnifiedRoleManagementPolicyRuleId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules_UnifiedRoleManagementPolicyRuleId,
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
    public partial class UnifiedroleManagementPolicyruleGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public UnifiedRoleManagementPolicyRuleTarget? Target { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleGetResponse> UnifiedroleManagementPolicyruleGetAsync()
        {
            var p = new UnifiedroleManagementPolicyruleGetParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyruleGetParameter, UnifiedroleManagementPolicyruleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleGetResponse> UnifiedroleManagementPolicyruleGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleManagementPolicyruleGetParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyruleGetParameter, UnifiedroleManagementPolicyruleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleGetResponse> UnifiedroleManagementPolicyruleGetAsync(UnifiedroleManagementPolicyruleGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyruleGetParameter, UnifiedroleManagementPolicyruleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleGetResponse> UnifiedroleManagementPolicyruleGetAsync(UnifiedroleManagementPolicyruleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyruleGetParameter, UnifiedroleManagementPolicyruleGetResponse>(parameter, cancellationToken);
        }
    }
}
