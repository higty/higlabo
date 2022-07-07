using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SwapshiftschangerequestApproveParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SwapShiftsChangeRequests_SwapShiftChangeRequestId_Approve,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_SwapShiftsChangeRequests_SwapShiftChangeRequestId_Approve: return $"/teams/{TeamId}/schedule/swapShiftsChangeRequests/{SwapShiftChangeRequestId}/approve";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Message { get; set; }
        public string TeamId { get; set; }
        public string SwapShiftChangeRequestId { get; set; }
    }
    public partial class SwapshiftschangerequestApproveResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestApproveResponse> SwapshiftschangerequestApproveAsync()
        {
            var p = new SwapshiftschangerequestApproveParameter();
            return await this.SendAsync<SwapshiftschangerequestApproveParameter, SwapshiftschangerequestApproveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestApproveResponse> SwapshiftschangerequestApproveAsync(CancellationToken cancellationToken)
        {
            var p = new SwapshiftschangerequestApproveParameter();
            return await this.SendAsync<SwapshiftschangerequestApproveParameter, SwapshiftschangerequestApproveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestApproveResponse> SwapshiftschangerequestApproveAsync(SwapshiftschangerequestApproveParameter parameter)
        {
            return await this.SendAsync<SwapshiftschangerequestApproveParameter, SwapshiftschangerequestApproveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestApproveResponse> SwapshiftschangerequestApproveAsync(SwapshiftschangerequestApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapshiftschangerequestApproveParameter, SwapshiftschangerequestApproveResponse>(parameter, cancellationToken);
        }
    }
}
