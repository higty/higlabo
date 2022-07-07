using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PolicyrootListRolemanagementpolicyassignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicyAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Policies_RoleManagementPolicyAssignments: return $"/policies/roleManagementPolicyAssignments";
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
    public partial class PolicyrootListRolemanagementpolicyassignmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedrolemanagementpolicyassignment?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleManagementPolicyAssignment
        {
            public string? Id { get; set; }
            public string? PolicyId { get; set; }
            public string? RoleDefinitionId { get; set; }
            public string? ScopeId { get; set; }
            public string? ScopeType { get; set; }
        }

        public UnifiedRoleManagementPolicyAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpolicyassignmentsResponse> PolicyrootListRolemanagementpolicyassignmentsAsync()
        {
            var p = new PolicyrootListRolemanagementpolicyassignmentsParameter();
            return await this.SendAsync<PolicyrootListRolemanagementpolicyassignmentsParameter, PolicyrootListRolemanagementpolicyassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpolicyassignmentsResponse> PolicyrootListRolemanagementpolicyassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new PolicyrootListRolemanagementpolicyassignmentsParameter();
            return await this.SendAsync<PolicyrootListRolemanagementpolicyassignmentsParameter, PolicyrootListRolemanagementpolicyassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpolicyassignmentsResponse> PolicyrootListRolemanagementpolicyassignmentsAsync(PolicyrootListRolemanagementpolicyassignmentsParameter parameter)
        {
            return await this.SendAsync<PolicyrootListRolemanagementpolicyassignmentsParameter, PolicyrootListRolemanagementpolicyassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyrootListRolemanagementpolicyassignmentsResponse> PolicyrootListRolemanagementpolicyassignmentsAsync(PolicyrootListRolemanagementpolicyassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PolicyrootListRolemanagementpolicyassignmentsParameter, PolicyrootListRolemanagementpolicyassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
