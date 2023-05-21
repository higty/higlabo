using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationListRoleeligibilityschedulerequestsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class RbacapplicationListRoleeligibilityschedulerequestsResponse : RestApiResponse
    {
        public UnifiedRoleEligibilityScheduleRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulerequestsResponse> RbacapplicationListRoleeligibilityschedulerequestsAsync()
        {
            var p = new RbacapplicationListRoleeligibilityschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulerequestsParameter, RbacapplicationListRoleeligibilityschedulerequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulerequestsResponse> RbacapplicationListRoleeligibilityschedulerequestsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleeligibilityschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulerequestsParameter, RbacapplicationListRoleeligibilityschedulerequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulerequestsResponse> RbacapplicationListRoleeligibilityschedulerequestsAsync(RbacapplicationListRoleeligibilityschedulerequestsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulerequestsParameter, RbacapplicationListRoleeligibilityschedulerequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulerequestsResponse> RbacapplicationListRoleeligibilityschedulerequestsAsync(RbacapplicationListRoleeligibilityschedulerequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulerequestsParameter, RbacapplicationListRoleeligibilityschedulerequestsResponse>(parameter, cancellationToken);
        }
    }
}
