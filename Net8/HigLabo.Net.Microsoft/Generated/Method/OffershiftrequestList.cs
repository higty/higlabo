using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class OfferShiftRequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_OfferShiftRequests: return $"/teams/{TeamId}/schedule/offerShiftRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_OfferShiftRequests,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class OfferShiftRequestListResponse : RestApiResponse
    {
        public DateTimeOffset? RecipientActionDateTime { get; set; }
        public string? RecipientActionMessage { get; set; }
        public string? RecipientUserId { get; set; }
        public string? SenderShiftId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestListResponse> OfferShiftRequestListAsync()
        {
            var p = new OfferShiftRequestListParameter();
            return await this.SendAsync<OfferShiftRequestListParameter, OfferShiftRequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestListResponse> OfferShiftRequestListAsync(CancellationToken cancellationToken)
        {
            var p = new OfferShiftRequestListParameter();
            return await this.SendAsync<OfferShiftRequestListParameter, OfferShiftRequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestListResponse> OfferShiftRequestListAsync(OfferShiftRequestListParameter parameter)
        {
            return await this.SendAsync<OfferShiftRequestListParameter, OfferShiftRequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OfferShiftRequestListResponse> OfferShiftRequestListAsync(OfferShiftRequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OfferShiftRequestListParameter, OfferShiftRequestListResponse>(parameter, cancellationToken);
        }
    }
}
