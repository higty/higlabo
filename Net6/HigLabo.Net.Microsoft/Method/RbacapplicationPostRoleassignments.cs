using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationPostRoleassignmentsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? RoleDefinitionId { get; set; }
        public string? PrincipalId { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? AppScopeId { get; set; }
    }
    public partial class RbacapplicationPostRoleassignmentsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? RoleDefinitionId { get; set; }
        public string? PrincipalId { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? AppScopeId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentsResponse> RbacapplicationPostRoleassignmentsAsync()
        {
            var p = new RbacapplicationPostRoleassignmentsParameter();
            return await this.SendAsync<RbacapplicationPostRoleassignmentsParameter, RbacapplicationPostRoleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentsResponse> RbacapplicationPostRoleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationPostRoleassignmentsParameter();
            return await this.SendAsync<RbacapplicationPostRoleassignmentsParameter, RbacapplicationPostRoleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentsResponse> RbacapplicationPostRoleassignmentsAsync(RbacapplicationPostRoleassignmentsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationPostRoleassignmentsParameter, RbacapplicationPostRoleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentsResponse> RbacapplicationPostRoleassignmentsAsync(RbacapplicationPostRoleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationPostRoleassignmentsParameter, RbacapplicationPostRoleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
