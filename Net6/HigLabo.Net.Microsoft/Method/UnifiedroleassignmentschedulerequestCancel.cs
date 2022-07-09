using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleAssignmentschedulerequestCancelParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UnifiedRoleAssignmentScheduleRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests_UnifiedRoleAssignmentScheduleRequestId_Cancel: return $"/roleManagement/directory/roleAssignmentScheduleRequests/{UnifiedRoleAssignmentScheduleRequestId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleRequests_UnifiedRoleAssignmentScheduleRequestId_Cancel,
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
    }
    public partial class UnifiedroleAssignmentschedulerequestCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestCancelResponse> UnifiedroleAssignmentschedulerequestCancelAsync()
        {
            var p = new UnifiedroleAssignmentschedulerequestCancelParameter();
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestCancelParameter, UnifiedroleAssignmentschedulerequestCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestCancelResponse> UnifiedroleAssignmentschedulerequestCancelAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleAssignmentschedulerequestCancelParameter();
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestCancelParameter, UnifiedroleAssignmentschedulerequestCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestCancelResponse> UnifiedroleAssignmentschedulerequestCancelAsync(UnifiedroleAssignmentschedulerequestCancelParameter parameter)
        {
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestCancelParameter, UnifiedroleAssignmentschedulerequestCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentschedulerequestCancelResponse> UnifiedroleAssignmentschedulerequestCancelAsync(UnifiedroleAssignmentschedulerequestCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleAssignmentschedulerequestCancelParameter, UnifiedroleAssignmentschedulerequestCancelResponse>(parameter, cancellationToken);
        }
    }
}
