using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationListRoleAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            AppScopeId,
            DirectoryScopeId,
            Id,
            RoleDefinitionId,
            PrincipalId,
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
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
    public partial class RbacapplicationListRoleAssignmentsResponse : RestApiResponse
    {
        public UnifiedRoleAssignment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentsResponse> RbacapplicationListRoleAssignmentsAsync()
        {
            var p = new RbacapplicationListRoleAssignmentsParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentsParameter, RbacapplicationListRoleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentsResponse> RbacapplicationListRoleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleAssignmentsParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentsParameter, RbacapplicationListRoleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentsResponse> RbacapplicationListRoleAssignmentsAsync(RbacapplicationListRoleAssignmentsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentsParameter, RbacapplicationListRoleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentsResponse> RbacapplicationListRoleAssignmentsAsync(RbacapplicationListRoleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentsParameter, RbacapplicationListRoleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
