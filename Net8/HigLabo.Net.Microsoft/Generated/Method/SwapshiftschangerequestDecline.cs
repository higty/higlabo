using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
    /// </summary>
    public partial class SwapShiftsChangeRequestDeclineParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? SwapShiftChangeRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_SwapShiftsChangeRequests_SwapShiftChangeRequestId_Decline: return $"/teams/{TeamId}/schedule/swapShiftsChangeRequests/{SwapShiftChangeRequestId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_SwapShiftsChangeRequests_SwapShiftChangeRequestId_Decline,
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
        public string? Message { get; set; }
    }
    public partial class SwapShiftsChangeRequestDeclineResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestDeclineResponse> SwapShiftsChangeRequestDeclineAsync()
        {
            var p = new SwapShiftsChangeRequestDeclineParameter();
            return await this.SendAsync<SwapShiftsChangeRequestDeclineParameter, SwapShiftsChangeRequestDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestDeclineResponse> SwapShiftsChangeRequestDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new SwapShiftsChangeRequestDeclineParameter();
            return await this.SendAsync<SwapShiftsChangeRequestDeclineParameter, SwapShiftsChangeRequestDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestDeclineResponse> SwapShiftsChangeRequestDeclineAsync(SwapShiftsChangeRequestDeclineParameter parameter)
        {
            return await this.SendAsync<SwapShiftsChangeRequestDeclineParameter, SwapShiftsChangeRequestDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/swapshiftschangerequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SwapShiftsChangeRequestDeclineResponse> SwapShiftsChangeRequestDeclineAsync(SwapShiftsChangeRequestDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SwapShiftsChangeRequestDeclineParameter, SwapShiftsChangeRequestDeclineResponse>(parameter, cancellationToken);
        }
    }
}
