using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationListRoleAssignmentschedulerequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests: return $"/roleManagement/directory/roleAssignmentScheduleRequests";
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
            RoleManagement_Directory_RoleAssignmentScheduleRequests,
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
    public partial class RbacapplicationListRoleAssignmentschedulerequestsResponse : RestApiResponse
    {
        public UnifiedRoleAssignmentScheduleRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulerequestsResponse> RbacapplicationListRoleAssignmentschedulerequestsAsync()
        {
            var p = new RbacapplicationListRoleAssignmentschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulerequestsParameter, RbacapplicationListRoleAssignmentschedulerequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulerequestsResponse> RbacapplicationListRoleAssignmentschedulerequestsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleAssignmentschedulerequestsParameter();
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulerequestsParameter, RbacapplicationListRoleAssignmentschedulerequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulerequestsResponse> RbacapplicationListRoleAssignmentschedulerequestsAsync(RbacapplicationListRoleAssignmentschedulerequestsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulerequestsParameter, RbacapplicationListRoleAssignmentschedulerequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleassignmentschedulerequests?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleAssignmentschedulerequestsResponse> RbacapplicationListRoleAssignmentschedulerequestsAsync(RbacapplicationListRoleAssignmentschedulerequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleAssignmentschedulerequestsParameter, RbacapplicationListRoleAssignmentschedulerequestsResponse>(parameter, cancellationToken);
        }
    }
}
