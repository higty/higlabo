using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleAssignmentScheduleRequestCancelParameter : IRestApiParameter
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
    public partial class UnifiedroleAssignmentScheduleRequestCancelResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentScheduleRequestCancelResponse> UnifiedroleAssignmentScheduleRequestCancelAsync()
        {
            var p = new UnifiedroleAssignmentScheduleRequestCancelParameter();
            return await this.SendAsync<UnifiedroleAssignmentScheduleRequestCancelParameter, UnifiedroleAssignmentScheduleRequestCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentScheduleRequestCancelResponse> UnifiedroleAssignmentScheduleRequestCancelAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleAssignmentScheduleRequestCancelParameter();
            return await this.SendAsync<UnifiedroleAssignmentScheduleRequestCancelParameter, UnifiedroleAssignmentScheduleRequestCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentScheduleRequestCancelResponse> UnifiedroleAssignmentScheduleRequestCancelAsync(UnifiedroleAssignmentScheduleRequestCancelParameter parameter)
        {
            return await this.SendAsync<UnifiedroleAssignmentScheduleRequestCancelParameter, UnifiedroleAssignmentScheduleRequestCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentScheduleRequestCancelResponse> UnifiedroleAssignmentScheduleRequestCancelAsync(UnifiedroleAssignmentScheduleRequestCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleAssignmentScheduleRequestCancelParameter, UnifiedroleAssignmentScheduleRequestCancelResponse>(parameter, cancellationToken);
        }
    }
}
