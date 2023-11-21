using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class OffershiftrequestGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId: return $"/teams/{TeamId}/schedule/offerShiftRequests/{OfferShiftRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId,
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
    public partial class OffershiftrequestGetResponse : RestApiResponse
    {
        public DateTimeOffset? RecipientActionDateTime { get; set; }
        public string? RecipientActionMessage { get; set; }
        public string? RecipientUserId { get; set; }
        public string? SenderShiftId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestGetResponse> OffershiftrequestGetAsync()
        {
            var p = new OffershiftrequestGetParameter();
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestGetResponse> OffershiftrequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new OffershiftrequestGetParameter();
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestGetResponse> OffershiftrequestGetAsync(OffershiftrequestGetParameter parameter)
        {
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestGetResponse> OffershiftrequestGetAsync(OffershiftrequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(parameter, cancellationToken);
        }
    }
}
