using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleRequests_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentScheduleRequests/filterByCurrentUser";
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
    public partial class UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleassignmentschedulerequest?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleAssignmentScheduleRequest
        {
            public string? Action { get; set; }
            public string? ApprovalId { get; set; }
            public string? AppScopeId { get; set; }
            public DateTimeOffset? CompletedDateTime { get; set; }
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? CustomData { get; set; }
            public string? DirectoryScopeId { get; set; }
            public string? Id { get; set; }
            public bool? IsValidationOnly { get; set; }
            public string? Justification { get; set; }
            public string? PrincipalId { get; set; }
            public string? RoleDefinitionId { get; set; }
            public RequestSchedule? ScheduleInfo { get; set; }
            public string? Status { get; set; }
            public string? TargetScheduleId { get; set; }
            public TicketInfo? TicketInfo { get; set; }
        }

        public UnifiedRoleAssignmentScheduleRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse> UnifiedroleassignmentschedulerequestFilterbycurrentuserAsync()
        {
            var p = new UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter, UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse> UnifiedroleassignmentschedulerequestFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter, UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse> UnifiedroleassignmentschedulerequestFilterbycurrentuserAsync(UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter, UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse> UnifiedroleassignmentschedulerequestFilterbycurrentuserAsync(UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentschedulerequestFilterbycurrentuserParameter, UnifiedroleassignmentschedulerequestFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
