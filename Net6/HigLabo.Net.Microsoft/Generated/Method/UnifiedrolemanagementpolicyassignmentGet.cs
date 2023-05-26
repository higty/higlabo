using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleManagementPolicyAssignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UnifiedRoleManagementPolicyAssignmentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_RoleManagementPolicyAssignments_UnifiedRoleManagementPolicyAssignmentId: return $"/policies/roleManagementPolicyAssignments/{UnifiedRoleManagementPolicyAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicyAssignments_UnifiedRoleManagementPolicyAssignmentId,
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
    public partial class UnifiedroleManagementPolicyAssignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? PolicyId { get; set; }
        public string? RoleDefinitionId { get; set; }
        public string? ScopeId { get; set; }
        public string? ScopeType { get; set; }
        public UnifiedRoleManagementPolicy? Policy { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyAssignmentGetResponse> UnifiedroleManagementPolicyAssignmentGetAsync()
        {
            var p = new UnifiedroleManagementPolicyAssignmentGetParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyAssignmentGetParameter, UnifiedroleManagementPolicyAssignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyAssignmentGetResponse> UnifiedroleManagementPolicyAssignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleManagementPolicyAssignmentGetParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyAssignmentGetParameter, UnifiedroleManagementPolicyAssignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyAssignmentGetResponse> UnifiedroleManagementPolicyAssignmentGetAsync(UnifiedroleManagementPolicyAssignmentGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyAssignmentGetParameter, UnifiedroleManagementPolicyAssignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyAssignmentGetResponse> UnifiedroleManagementPolicyAssignmentGetAsync(UnifiedroleManagementPolicyAssignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyAssignmentGetParameter, UnifiedroleManagementPolicyAssignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
