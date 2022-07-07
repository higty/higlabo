using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentschedulerequestCancelParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleRequests_UnifiedRoleAssignmentScheduleRequestId_Cancel,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleRequests_UnifiedRoleAssignmentScheduleRequestId_Cancel: return $"/roleManagement/directory/roleAssignmentScheduleRequests/{UnifiedRoleAssignmentScheduleRequestId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UnifiedRoleAssignmentScheduleRequestId { get; set; }
    }
    public partial class UnifiedroleassignmentschedulerequestCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestCancelResponse> UnifiedroleassignmentschedulerequestCancelAsync()
        {
            var p = new UnifiedroleassignmentschedulerequestCancelParameter();
            return await this.SendAsync<UnifiedroleassignmentschedulerequestCancelParameter, UnifiedroleassignmentschedulerequestCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestCancelResponse> UnifiedroleassignmentschedulerequestCancelAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentschedulerequestCancelParameter();
            return await this.SendAsync<UnifiedroleassignmentschedulerequestCancelParameter, UnifiedroleassignmentschedulerequestCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestCancelResponse> UnifiedroleassignmentschedulerequestCancelAsync(UnifiedroleassignmentschedulerequestCancelParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentschedulerequestCancelParameter, UnifiedroleassignmentschedulerequestCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentschedulerequestCancelResponse> UnifiedroleassignmentschedulerequestCancelAsync(UnifiedroleassignmentschedulerequestCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentschedulerequestCancelParameter, UnifiedroleassignmentschedulerequestCancelResponse>(parameter, cancellationToken);
        }
    }
}
