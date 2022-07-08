using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentScheduleRequests/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Action,
            ApprovalId,
            AppScopeId,
            CompletedDateTime,
            CreatedBy,
            CreatedDateTime,
            CustomData,
            DirectoryScopeId,
            Id,
            IsValidationOnly,
            Justification,
            PrincipalId,
            RoleDefinitionId,
            ScheduleInfo,
            Status,
            TargetScheduleId,
            TicketInfo,
            ActivatedUsing,
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
            TargetSchedule,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleRequests_FilterByCurrentUser,
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
    public partial class UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse : RestApiResponse
    {
        public UnifiedRoleAssignmentScheduleRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse> UnifiedroleAssignmentschedulerequestFilterbycurrentUserAsync()
        {
            var p = new UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter, UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse> UnifiedroleAssignmentschedulerequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter, UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse> UnifiedroleAssignmentschedulerequestFilterbycurrentUserAsync(UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter, UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse> UnifiedroleAssignmentschedulerequestFilterbycurrentUserAsync(UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestFilterbycurrentUserParameter, UnifiedroleAssignmentschedulerequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
