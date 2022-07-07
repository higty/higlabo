using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationListRoleeligibilityschedulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilitySchedules,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilitySchedules: return $"/roleManagement/directory/roleEligibilitySchedules";
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
    public partial class RbacapplicationListRoleeligibilityschedulesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleeligibilityschedule?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleEligibilitySchedule
        {
            public string? AppScopeId { get; set; }
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

        public UnifiedRoleEligibilitySchedule[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync()
        {
            var p = new RbacapplicationListRoleeligibilityschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleeligibilityschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync(RbacapplicationListRoleeligibilityschedulesParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync(RbacapplicationListRoleeligibilityschedulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(parameter, cancellationToken);
        }
    }
}
