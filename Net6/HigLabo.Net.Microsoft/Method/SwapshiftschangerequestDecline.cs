using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SwapshiftschangerequestDeclineParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SwapShiftsChangeRequests_SwapShiftChangeRequestId_Decline,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_SwapShiftsChangeRequests_SwapShiftChangeRequestId_Decline: return $"/teams/{TeamId}/schedule/swapShiftsChangeRequests/{SwapShiftChangeRequestId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Message { get; set; }
        public string TeamId { get; set; }
        public string SwapShiftChangeRequestId { get; set; }
    }
    public partial class SwapshiftschangerequestDeclineResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestDeclineResponse> SwapshiftschangerequestDeclineAsync()
        {
            var p = new SwapshiftschangerequestDeclineParameter();
            return await this.SendAsync<SwapshiftschangerequestDeclineParameter, SwapshiftschangerequestDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestDeclineResponse> SwapshiftschangerequestDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new SwapshiftschangerequestDeclineParameter();
            return await this.SendAsync<SwapshiftschangerequestDeclineParameter, SwapshiftschangerequestDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestDeclineResponse> SwapshiftschangerequestDeclineAsync(SwapshiftschangerequestDeclineParameter parameter)
        {
            return await this.SendAsync<SwapshiftschangerequestDeclineParameter, SwapshiftschangerequestDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestDeclineResponse> SwapshiftschangerequestDeclineAsync(SwapshiftschangerequestDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapshiftschangerequestDeclineParameter, SwapshiftschangerequestDeclineResponse>(parameter, cancellationToken);
        }
    }
}
