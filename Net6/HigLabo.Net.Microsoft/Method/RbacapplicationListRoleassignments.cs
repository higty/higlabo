using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationListRoleassignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignments,
            RoleManagement_EntitlementManagement_RoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignments: return $"/roleManagement/directory/roleAssignments";
                    case ApiPath.RoleManagement_EntitlementManagement_RoleAssignments: return $"/roleManagement/entitlementManagement/roleAssignments";
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
    public partial class RbacapplicationListRoleassignmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleassignment?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleAssignment
        {
            public string? Id { get; set; }
            public string? RoleDefinitionId { get; set; }
            public string? PrincipalId { get; set; }
            public string? DirectoryScopeId { get; set; }
            public string? AppScopeId { get; set; }
        }

        public UnifiedRoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentsResponse> RbacapplicationListRoleassignmentsAsync()
        {
            var p = new RbacapplicationListRoleassignmentsParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentsParameter, RbacapplicationListRoleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentsResponse> RbacapplicationListRoleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleassignmentsParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentsParameter, RbacapplicationListRoleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentsResponse> RbacapplicationListRoleassignmentsAsync(RbacapplicationListRoleassignmentsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentsParameter, RbacapplicationListRoleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentsResponse> RbacapplicationListRoleassignmentsAsync(RbacapplicationListRoleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentsParameter, RbacapplicationListRoleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
