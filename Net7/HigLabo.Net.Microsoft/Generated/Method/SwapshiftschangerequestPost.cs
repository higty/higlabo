using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
    /// </summary>
    public partial class SwapshiftschangerequestPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_SwapShiftsChangeRequests: return $"/teams/{TeamId}/schedule/swapShiftsChangeRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_SwapShiftsChangeRequests,
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
        public string? RecipientShiftId { get; set; }
    }
    public partial class SwapshiftschangerequestPostResponse : RestApiResponse
    {
        public string? RecipientShiftId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync()
        {
            var p = new SwapshiftschangerequestPostParameter();
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync(CancellationToken cancellationToken)
        {
            var p = new SwapshiftschangerequestPostParameter();
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync(SwapshiftschangerequestPostParameter parameter)
        {
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapshiftschangerequestPostResponse> SwapshiftschangerequestPostAsync(SwapshiftschangerequestPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapshiftschangerequestPostParameter, SwapshiftschangerequestPostResponse>(parameter, cancellationToken);
        }
    }
}
