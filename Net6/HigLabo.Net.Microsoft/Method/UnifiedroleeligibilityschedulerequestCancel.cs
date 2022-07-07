using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleeligibilityschedulerequestCancelParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilityScheduleRequests_UnifiedRoleEligibilityScheduleRequestId_Cancel,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleRequests_UnifiedRoleEligibilityScheduleRequestId_Cancel: return $"/roleManagement/directory/roleEligibilityScheduleRequests/{UnifiedRoleEligibilityScheduleRequestId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UnifiedRoleEligibilityScheduleRequestId { get; set; }
    }
    public partial class UnifiedroleeligibilityschedulerequestCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestCancelResponse> UnifiedroleeligibilityschedulerequestCancelAsync()
        {
            var p = new UnifiedroleeligibilityschedulerequestCancelParameter();
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestCancelParameter, UnifiedroleeligibilityschedulerequestCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestCancelResponse> UnifiedroleeligibilityschedulerequestCancelAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityschedulerequestCancelParameter();
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestCancelParameter, UnifiedroleeligibilityschedulerequestCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestCancelResponse> UnifiedroleeligibilityschedulerequestCancelAsync(UnifiedroleeligibilityschedulerequestCancelParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestCancelParameter, UnifiedroleeligibilityschedulerequestCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedulerequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityschedulerequestCancelResponse> UnifiedroleeligibilityschedulerequestCancelAsync(UnifiedroleeligibilityschedulerequestCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityschedulerequestCancelParameter, UnifiedroleeligibilityschedulerequestCancelResponse>(parameter, cancellationToken);
        }
    }
}
