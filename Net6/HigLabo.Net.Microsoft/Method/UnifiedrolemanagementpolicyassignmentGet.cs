using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedrolemanagementpolicyassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicyAssignments_UnifiedRoleManagementPolicyAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_RoleManagementPolicyAssignments_UnifiedRoleManagementPolicyAssignmentId: return $"/policies/roleManagementPolicyAssignments/{UnifiedRoleManagementPolicyAssignmentId}";
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
        public string UnifiedRoleManagementPolicyAssignmentId { get; set; }
    }
    public partial class UnifiedrolemanagementpolicyassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? PolicyId { get; set; }
        public string? RoleDefinitionId { get; set; }
        public string? ScopeId { get; set; }
        public string? ScopeType { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyassignmentGetResponse> UnifiedrolemanagementpolicyassignmentGetAsync()
        {
            var p = new UnifiedrolemanagementpolicyassignmentGetParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyassignmentGetParameter, UnifiedrolemanagementpolicyassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyassignmentGetResponse> UnifiedrolemanagementpolicyassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedrolemanagementpolicyassignmentGetParameter();
            return await this.SendAsync<UnifiedrolemanagementpolicyassignmentGetParameter, UnifiedrolemanagementpolicyassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyassignmentGetResponse> UnifiedrolemanagementpolicyassignmentGetAsync(UnifiedrolemanagementpolicyassignmentGetParameter parameter)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyassignmentGetParameter, UnifiedrolemanagementpolicyassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedrolemanagementpolicyassignmentGetResponse> UnifiedrolemanagementpolicyassignmentGetAsync(UnifiedrolemanagementpolicyassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedrolemanagementpolicyassignmentGetParameter, UnifiedrolemanagementpolicyassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
