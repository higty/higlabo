using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
    /// </summary>
    public partial class OfferShiftRequestDeclineParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? OfferShiftRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId_Decline: return $"/teams/{TeamId}/schedule/offerShiftRequests/{OfferShiftRequestId}/decline";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId_Decline,
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
    public partial class OfferShiftRequestDeclineResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestDeclineResponse> OfferShiftRequestDeclineAsync()
        {
            var p = new OfferShiftRequestDeclineParameter();
            return await this.SendAsync<OfferShiftRequestDeclineParameter, OfferShiftRequestDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestDeclineResponse> OfferShiftRequestDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new OfferShiftRequestDeclineParameter();
            return await this.SendAsync<OfferShiftRequestDeclineParameter, OfferShiftRequestDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestDeclineResponse> OfferShiftRequestDeclineAsync(OfferShiftRequestDeclineParameter parameter)
        {
            return await this.SendAsync<OfferShiftRequestDeclineParameter, OfferShiftRequestDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestDeclineResponse> OfferShiftRequestDeclineAsync(OfferShiftRequestDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OfferShiftRequestDeclineParameter, OfferShiftRequestDeclineResponse>(parameter, cancellationToken);
        }
    }
}
