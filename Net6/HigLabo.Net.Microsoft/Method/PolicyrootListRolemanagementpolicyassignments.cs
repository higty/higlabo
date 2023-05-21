using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
    /// </summary>
    public partial class PolicyRootListRoleManagementPolicyAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_RoleManagementPolicyAssignments: return $"/policies/roleManagementPolicyAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            PolicyId,
            RoleDefinitionId,
            ScopeId,
            ScopeType,
            Policy,
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicyAssignments,
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
    public partial class PolicyRootListRoleManagementPolicyAssignmentsResponse : RestApiResponse
    {
        public UnifiedRoleManagementPolicyAssignment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync()
        {
            var p = new PolicyRootListRoleManagementPolicyAssignmentsParameter();
            return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new PolicyRootListRoleManagementPolicyAssignmentsParameter();
            return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync(PolicyRootListRoleManagementPolicyAssignmentsParameter parameter)
        {
            return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicyassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementPolicyAssignmentsResponse> PolicyRootListRoleManagementPolicyAssignmentsAsync(PolicyRootListRoleManagementPolicyAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PolicyRootListRoleManagementPolicyAssignmentsParameter, PolicyRootListRoleManagementPolicyAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
