using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationListRoleAssignmentscheduleinstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleInstances: return $"/roleManagement/directory/roleAssignmentScheduleInstances";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppScopeId,
            AssignmentType,
            DirectoryScopeId,
            EndDateTime,
            Id,
            MemberType,
            PrincipalId,
            RoleAssignmentOriginId,
            RoleAssignmentScheduleId,
            RoleDefinitionId,
            StartDateTime,
            ActivatedUsing,
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleInstances,
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
    public partial class RbacapplicationListRoleAssignmentscheduleinstancesResponse : RestApiResponse
    {
        public UnifiedRoleAssignmentScheduleInstance[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentscheduleinstancesResponse> RbacapplicationListRoleAssignmentscheduleinstancesAsync()
        {
            var p = new RbacapplicationListRoleAssignmentscheduleinstancesParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentscheduleinstancesParameter, RbacapplicationListRoleAssignmentscheduleinstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentscheduleinstancesResponse> RbacapplicationListRoleAssignmentscheduleinstancesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleAssignmentscheduleinstancesParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentscheduleinstancesParameter, RbacapplicationListRoleAssignmentscheduleinstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentscheduleinstancesResponse> RbacapplicationListRoleAssignmentscheduleinstancesAsync(RbacapplicationListRoleAssignmentscheduleinstancesParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentscheduleinstancesParameter, RbacapplicationListRoleAssignmentscheduleinstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleAssignmentscheduleinstancesResponse> RbacapplicationListRoleAssignmentscheduleinstancesAsync(RbacapplicationListRoleAssignmentscheduleinstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentscheduleinstancesParameter, RbacapplicationListRoleAssignmentscheduleinstancesResponse>(parameter, cancellationToken);
        }
    }
}
