using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleeligibilityschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationPostRoleeligibilityschedulerequestsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleRequests: return $"/roleManagement/directory/roleEligibilityScheduleRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum RbacapplicationPostRoleeligibilityschedulerequestsParameterUnifiedRoleScheduleRequestActions
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
        public enum UnifiedRoleEligibilityScheduleRequestUnifiedRoleScheduleRequestActions
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
            RoleManagement_Directory_RoleEligibilityScheduleRequests,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public RbacapplicationPostRoleeligibilityschedulerequestsParameterUnifiedRoleScheduleRequestActions Action { get; set; }
        public string? AppScopeId { get; set; }
        public string? DirectoryScopeId { get; set; }
        public bool? IsValidationOnly { get; set; }
        public string? Justification { get; set; }
        public string? PrincipalId { get; set; }
        public string? RoleDefinitionId { get; set; }
        public RequestSchedule? ScheduleInfo { get; set; }
        public TicketInfo? TicketInfo { get; set; }
        public string? ApprovalId { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? CustomData { get; set; }
        public string? Id { get; set; }
        public string? Status { get; set; }
        public string? TargetScheduleId { get; set; }
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
        public UnifiedRoleEligibilitySchedule? TargetSchedule { get; set; }
    }
    public partial class RbacapplicationPostRoleeligibilityschedulerequestsResponse : RestApiResponse
    {
        public enum UnifiedRoleEligibilityScheduleRequestUnifiedRoleScheduleRequestActions
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

        public UnifiedRoleEligibilityScheduleRequestUnifiedRoleScheduleRequestActions Action { get; set; }
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
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
        public UnifiedRoleEligibilitySchedule? TargetSchedule { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleeligibilityschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleeligibilityschedulerequestsResponse> RbacapplicationPostRoleeligibilityschedulerequestsAsync()
        {
            var p = new RbacapplicationPostRoleeligibilityschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationPostRoleeligibilityschedulerequestsParameter, RbacapplicationPostRoleeligibilityschedulerequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleeligibilityschedulerequestsResponse> RbacapplicationPostRoleeligibilityschedulerequestsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationPostRoleeligibilityschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationPostRoleeligibilityschedulerequestsParameter, RbacapplicationPostRoleeligibilityschedulerequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleeligibilityschedulerequestsResponse> RbacapplicationPostRoleeligibilityschedulerequestsAsync(RbacapplicationPostRoleeligibilityschedulerequestsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationPostRoleeligibilityschedulerequestsParameter, RbacapplicationPostRoleeligibilityschedulerequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-post-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationPostRoleeligibilityschedulerequestsResponse> RbacapplicationPostRoleeligibilityschedulerequestsAsync(RbacapplicationPostRoleeligibilityschedulerequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationPostRoleeligibilityschedulerequestsParameter, RbacapplicationPostRoleeligibilityschedulerequestsResponse>(parameter, cancellationToken);
        }
    }
}
