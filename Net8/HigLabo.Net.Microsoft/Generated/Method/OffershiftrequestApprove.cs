using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-approve?view=graph-rest-1.0
    /// </summary>
    public partial class OfferShiftRequestApproveParameter : IRestApiParameter
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
                    case ApiPath.Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId_Approve: return $"/teams/{TeamId}/schedule/offerShiftRequests/{OfferShiftRequestId}/approve";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId_Approve,
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
    public partial class OfferShiftRequestApproveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-approve?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestApproveResponse> OfferShiftRequestApproveAsync()
        {
            var p = new OfferShiftRequestApproveParameter();
            return await this.SendAsync<OfferShiftRequestApproveParameter, OfferShiftRequestApproveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestApproveResponse> OfferShiftRequestApproveAsync(CancellationToken cancellationToken)
        {
            var p = new OfferShiftRequestApproveParameter();
            return await this.SendAsync<OfferShiftRequestApproveParameter, OfferShiftRequestApproveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestApproveResponse> OfferShiftRequestApproveAsync(OfferShiftRequestApproveParameter parameter)
        {
            return await this.SendAsync<OfferShiftRequestApproveParameter, OfferShiftRequestApproveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestApproveResponse> OfferShiftRequestApproveAsync(OfferShiftRequestApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OfferShiftRequestApproveParameter, OfferShiftRequestApproveResponse>(parameter, cancellationToken);
        }
    }
}
