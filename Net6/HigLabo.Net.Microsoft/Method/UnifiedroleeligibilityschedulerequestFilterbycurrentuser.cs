using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilityScheduleRequests_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleRequests_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilityScheduleRequests/filterByCurrentUser";
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
    public partial class UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleeligibilityschedulerequest?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleEligibilityScheduleRequest
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
        }

        public UnifiedRoleEligibilityScheduleRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentuserAsync()
        {
            var p = new UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentuserAsync(UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentuserAsync(UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentuserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
