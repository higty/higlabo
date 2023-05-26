using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleManagementPolicyListRulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UnifiedRoleManagementPolicyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules: return $"/policies/roleManagementPolicies/{UnifiedRoleManagementPolicyId}/rules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules,
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
    public partial class UnifiedroleManagementPolicyListRulesResponse : RestApiResponse
    {
        public UnifiedRoleManagementPolicyRule[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyListRulesResponse> UnifiedroleManagementPolicyListRulesAsync()
        {
            var p = new UnifiedroleManagementPolicyListRulesParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyListRulesParameter, UnifiedroleManagementPolicyListRulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyListRulesResponse> UnifiedroleManagementPolicyListRulesAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleManagementPolicyListRulesParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyListRulesParameter, UnifiedroleManagementPolicyListRulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyListRulesResponse> UnifiedroleManagementPolicyListRulesAsync(UnifiedroleManagementPolicyListRulesParameter parameter)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyListRulesParameter, UnifiedroleManagementPolicyListRulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicy-list-rules?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyListRulesResponse> UnifiedroleManagementPolicyListRulesAsync(UnifiedroleManagementPolicyListRulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyListRulesParameter, UnifiedroleManagementPolicyListRulesResponse>(parameter, cancellationToken);
        }
    }
}
