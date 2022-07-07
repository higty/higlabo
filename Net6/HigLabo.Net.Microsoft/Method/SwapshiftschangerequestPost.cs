using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SwapshiftschangerequestPostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Schedule_SwapShiftsChangeRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_SwapShiftsChangeRequests: return $"/teams/{TeamId}/schedule/swapShiftsChangeRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
    }
    public partial class SwapshiftschangerequestPostResponse : RestApiResponse
    {
        public string? RecipientShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync()
        {
            var p = new SwapshiftschangerequestPostParameter();
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync(CancellationToken cancellationToken)
        {
            var p = new SwapshiftschangerequestPostParameter();
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync(SwapshiftschangerequestPostParameter parameter)
        {
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync(SwapshiftschangerequestPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(parameter, cancellationToken);
        }
    }
}
