using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleRequests_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilityScheduleRequests/filterByCurrentUser";
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
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
            TargetSchedule,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilityScheduleRequests_FilterByCurrentUser,
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
    public partial class UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse : RestApiResponse
    {
        public UnifiedRoleEligibilityScheduleRequest[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentUserAsync()
        {
            var p = new UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentUserAsync(UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse> UnifiedroleeligibilityschedulerequestFilterbycurrentUserAsync(UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestFilterbycurrentUserParameter, UnifiedroleeligibilityschedulerequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
