using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationListRoleassignmentscheduleinstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleInstances,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleInstances: return $"/roleManagement/directory/roleAssignmentScheduleInstances";
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
    public partial class RbacapplicationListRoleassignmentscheduleinstancesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleassignmentscheduleinstance?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleAssignmentScheduleInstance
        {
            public string? AppScopeId { get; set; }
            public string? AssignmentType { get; set; }
            public string? DirectoryScopeId { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
            public string? Id { get; set; }
            public string? MemberType { get; set; }
            public string? PrincipalId { get; set; }
            public string? RoleAssignmentOriginId { get; set; }
            public string? RoleAssignmentScheduleId { get; set; }
            public string? RoleDefinitionId { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
        }

        public UnifiedRoleAssignmentScheduleInstance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentscheduleinstancesResponse> RbacapplicationListRoleassignmentscheduleinstancesAsync()
        {
            var p = new RbacapplicationListRoleassignmentscheduleinstancesParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentscheduleinstancesParameter, RbacapplicationListRoleassignmentscheduleinstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentscheduleinstancesResponse> RbacapplicationListRoleassignmentscheduleinstancesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleassignmentscheduleinstancesParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentscheduleinstancesParameter, RbacapplicationListRoleassignmentscheduleinstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentscheduleinstancesResponse> RbacapplicationListRoleassignmentscheduleinstancesAsync(RbacapplicationListRoleassignmentscheduleinstancesParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentscheduleinstancesParameter, RbacapplicationListRoleassignmentscheduleinstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentscheduleinstancesResponse> RbacapplicationListRoleassignmentscheduleinstancesAsync(RbacapplicationListRoleassignmentscheduleinstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentscheduleinstancesParameter, RbacapplicationListRoleassignmentscheduleinstancesResponse>(parameter, cancellationToken);
        }
    }
}
