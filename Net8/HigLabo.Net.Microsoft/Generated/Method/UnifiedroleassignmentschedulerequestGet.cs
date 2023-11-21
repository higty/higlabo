using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleAssignmentschedulerequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UnifiedRoleAssignmentScheduleRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests_UnifiedRoleAssignmentScheduleRequestId: return $"/roleManagement/directory/roleAssignmentScheduleRequests/{UnifiedRoleAssignmentScheduleRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleRequests_UnifiedRoleAssignmentScheduleRequestId,
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
    public partial class UnifiedroleAssignmentschedulerequestGetResponse : RestApiResponse
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
        public UnifiedRoleEligibilitySchedule? ActivatedUsing { get; set; }
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
        public UnifiedRoleAssignmentSchedule? TargetSchedule { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentschedulerequestGetResponse> UnifiedroleAssignmentschedulerequestGetAsync()
        {
            var p = new UnifiedroleAssignmentschedulerequestGetParameter();
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestGetParameter, UnifiedroleAssignmentschedulerequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentschedulerequestGetResponse> UnifiedroleAssignmentschedulerequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleAssignmentschedulerequestGetParameter();
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestGetParameter, UnifiedroleAssignmentschedulerequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentschedulerequestGetResponse> UnifiedroleAssignmentschedulerequestGetAsync(UnifiedroleAssignmentschedulerequestGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestGetParameter, UnifiedroleAssignmentschedulerequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentschedulerequestGetResponse> UnifiedroleAssignmentschedulerequestGetAsync(UnifiedroleAssignmentschedulerequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestGetParameter, UnifiedroleAssignmentschedulerequestGetResponse>(parameter, cancellationToken);
        }
    }
}
