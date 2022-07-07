using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentscheduleFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentSchedules_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentSchedules/filterByCurrentUser";
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
    public partial class UnifiedroleassignmentscheduleFilterbycurrentuserResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleFilterbycurrentuserResponse> UnifiedroleassignmentscheduleFilterbycurrentuserAsync()
        {
            var p = new UnifiedroleassignmentscheduleFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleFilterbycurrentuserParameter, UnifiedroleassignmentscheduleFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleFilterbycurrentuserResponse> UnifiedroleassignmentscheduleFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentscheduleFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleFilterbycurrentuserParameter, UnifiedroleassignmentscheduleFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleFilterbycurrentuserResponse> UnifiedroleassignmentscheduleFilterbycurrentuserAsync(UnifiedroleassignmentscheduleFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleFilterbycurrentuserParameter, UnifiedroleassignmentscheduleFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleFilterbycurrentuserResponse> UnifiedroleassignmentscheduleFilterbycurrentuserAsync(UnifiedroleassignmentscheduleFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleFilterbycurrentuserParameter, UnifiedroleassignmentscheduleFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
