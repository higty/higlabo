using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationListRoleAssignmentschedulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules: return $"/roleManagement/directory/roleAssignmentSchedules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppScopeId,
            AssignmentType,
            CreatedDateTime,
            CreatedUsing,
            DirectoryScopeId,
            Id,
            MemberType,
            ModifiedDateTime,
            PrincipalId,
            RoleDefinitionId,
            ScheduleInfo,
            Status,
            ActivatedUsing,
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentSchedules,
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
    public partial class RbacapplicationListRoleAssignmentschedulesResponse : RestApiResponse
    {
        public UnifiedRoleAssignmentSchedule[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulesResponse> RbacapplicationListRoleAssignmentschedulesAsync()
        {
            var p = new RbacapplicationListRoleAssignmentschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulesParameter, RbacapplicationListRoleAssignmentschedulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulesResponse> RbacapplicationListRoleAssignmentschedulesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleAssignmentschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulesParameter, RbacapplicationListRoleAssignmentschedulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulesResponse> RbacapplicationListRoleAssignmentschedulesAsync(RbacapplicationListRoleAssignmentschedulesParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulesParameter, RbacapplicationListRoleAssignmentschedulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulesResponse> RbacapplicationListRoleAssignmentschedulesAsync(RbacapplicationListRoleAssignmentschedulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulesParameter, RbacapplicationListRoleAssignmentschedulesResponse>(parameter, cancellationToken);
        }
    }
}
