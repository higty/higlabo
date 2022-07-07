using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RbacapplicationPostRoleassignmentschedulerequestsParameter : IRestApiParameter
    {
        public enum RbacapplicationPostRoleassignmentschedulerequestsParameterUnifiedRoleScheduleRequestActions
        {
            AdminAssign,
            AdminUpdate,
            AdminRemove,
            SelfActivate,
            SelfDeactivate,
            AdminExtend,
            AdminRenew,
            SelfExtend,
            SelfRenew,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public RbacapplicationPostRoleassignmentschedulerequestsParameterUnifiedRoleScheduleRequestActions Action { get; set; }
        public string? CustomData { get; set; }
        public string? PrincipalId { get; set; }
        public string? RoleDefinitionId { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? AppScopeId { get; set; }
        public string? Justification { get; set; }
        public RequestSchedule? ScheduleInfo { get; set; }
        public TicketInfo? TicketInfo { get; set; }
    }
    public partial class RbacapplicationPostRoleassignmentschedulerequestsResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentschedulerequestsResponse> RbacapplicationPostRoleassignmentschedulerequestsAsync()
        {
            var p = new RbacapplicationPostRoleassignmentschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationPostRoleassignmentschedulerequestsParameter, RbacapplicationPostRoleassignmentschedulerequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentschedulerequestsResponse> RbacapplicationPostRoleassignmentschedulerequestsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationPostRoleassignmentschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationPostRoleassignmentschedulerequestsParameter, RbacapplicationPostRoleassignmentschedulerequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentschedulerequestsResponse> RbacapplicationPostRoleassignmentschedulerequestsAsync(RbacapplicationPostRoleassignmentschedulerequestsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationPostRoleassignmentschedulerequestsParameter, RbacapplicationPostRoleassignmentschedulerequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rbacapplication-post-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleassignmentschedulerequestsResponse> RbacapplicationPostRoleassignmentschedulerequestsAsync(RbacapplicationPostRoleassignmentschedulerequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationPostRoleassignmentschedulerequestsParameter, RbacapplicationPostRoleassignmentschedulerequestsResponse>(parameter, cancellationToken);
        }
    }
}
