using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationListRoleassignmentschedulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentSchedules,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules: return $"/roleManagement/directory/roleAssignmentSchedules";
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
    public partial class RbacapplicationListRoleassignmentschedulesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleassignmentschedule?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleAssignmentSchedule
        {
            public string? AppScopeId { get; set; }
            public string? AssignmentType { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? CreatedUsing { get; set; }
            public string? DirectoryScopeId { get; set; }
            public string? Id { get; set; }
            public string? MemberType { get; set; }
            public DateTimeOffset? ModifiedDateTime { get; set; }
            public string? PrincipalId { get; set; }
            public string? RoleDefinitionId { get; set; }
            public RequestSchedule? ScheduleInfo { get; set; }
            public string? Status { get; set; }
        }

        public UnifiedRoleAssignmentSchedule[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulesResponse> RbacapplicationListRoleassignmentschedulesAsync()
        {
            var p = new RbacapplicationListRoleassignmentschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulesParameter, RbacapplicationListRoleassignmentschedulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulesResponse> RbacapplicationListRoleassignmentschedulesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleassignmentschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulesParameter, RbacapplicationListRoleassignmentschedulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulesResponse> RbacapplicationListRoleassignmentschedulesAsync(RbacapplicationListRoleassignmentschedulesParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulesParameter, RbacapplicationListRoleassignmentschedulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulesResponse> RbacapplicationListRoleassignmentschedulesAsync(RbacapplicationListRoleassignmentschedulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulesParameter, RbacapplicationListRoleassignmentschedulesResponse>(parameter, cancellationToken);
        }
    }
}
