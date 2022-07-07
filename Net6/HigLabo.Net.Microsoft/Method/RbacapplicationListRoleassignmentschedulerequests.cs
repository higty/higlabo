using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationListRoleassignmentschedulerequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests: return $"/roleManagement/directory/roleAssignmentScheduleRequests";
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
    public partial class RbacapplicationListRoleassignmentschedulerequestsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulerequestsResponse> RbacapplicationListRoleassignmentschedulerequestsAsync()
        {
            var p = new RbacapplicationListRoleassignmentschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulerequestsParameter, RbacapplicationListRoleassignmentschedulerequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulerequestsResponse> RbacapplicationListRoleassignmentschedulerequestsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleassignmentschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulerequestsParameter, RbacapplicationListRoleassignmentschedulerequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulerequestsResponse> RbacapplicationListRoleassignmentschedulerequestsAsync(RbacapplicationListRoleassignmentschedulerequestsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulerequestsParameter, RbacapplicationListRoleassignmentschedulerequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleassignmentschedulerequestsResponse> RbacapplicationListRoleassignmentschedulerequestsAsync(RbacapplicationListRoleassignmentschedulerequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleassignmentschedulerequestsParameter, RbacapplicationListRoleassignmentschedulerequestsResponse>(parameter, cancellationToken);
        }
    }
}
