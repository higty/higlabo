using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationPostRoleAssignmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignments: return $"/roleManagement/directory/roleAssignments";
                    case ApiPath.RoleManagement_EntitlementManagement_RoleAssignments: return $"/roleManagement/entitlementManagement/roleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignments,
            RoleManagement_EntitlementManagement_RoleAssignments,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? RoleDefinitionId { get; set; }
        public string? PrincipalId { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? AppScopeId { get; set; }
        public string? Id { get; set; }
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
    }
    public partial class RbacapplicationPostRoleAssignmentsResponse : RestApiResponse
    {
        public string? AppScopeId { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? Id { get; set; }
        public string? RoleDefinitionId { get; set; }
        public string? PrincipalId { get; set; }
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationPostRoleAssignmentsResponse> RbacapplicationPostRoleAssignmentsAsync()
        {
            var p = new RbacapplicationPostRoleAssignmentsParameter();
            return await this.SendAsync<RbacapplicationPostRoleAssignmentsParameter, RbacapplicationPostRoleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationPostRoleAssignmentsResponse> RbacapplicationPostRoleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationPostRoleAssignmentsParameter();
            return await this.SendAsync<RbacapplicationPostRoleAssignmentsParameter, RbacapplicationPostRoleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationPostRoleAssignmentsResponse> RbacapplicationPostRoleAssignmentsAsync(RbacapplicationPostRoleAssignmentsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationPostRoleAssignmentsParameter, RbacapplicationPostRoleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationPostRoleAssignmentsResponse> RbacapplicationPostRoleAssignmentsAsync(RbacapplicationPostRoleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationPostRoleAssignmentsParameter, RbacapplicationPostRoleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
