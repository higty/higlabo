using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OffershiftrequestDeclineParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }
            public string OfferShiftRequestId { get; set; }

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
    public partial class OffershiftrequestDeclineResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestDeclineResponse> OffershiftrequestDeclineAsync()
        {
            var p = new OffershiftrequestDeclineParameter();
            return await this.SendAsync<OffershiftrequestDeclineParameter, OffershiftrequestDeclineResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestDeclineResponse> OffershiftrequestDeclineAsync(CancellationToken cancellationToken)
        {
            var p = new OffershiftrequestDeclineParameter();
            return await this.SendAsync<OffershiftrequestDeclineParameter, OffershiftrequestDeclineResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestDeclineResponse> OffershiftrequestDeclineAsync(OffershiftrequestDeclineParameter parameter)
        {
            return await this.SendAsync<OffershiftrequestDeclineParameter, OffershiftrequestDeclineResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-decline?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestDeclineResponse> OffershiftrequestDeclineAsync(OffershiftrequestDeclineParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OffershiftrequestDeclineParameter, OffershiftrequestDeclineResponse>(parameter, cancellationToken);
        }
    }
}
