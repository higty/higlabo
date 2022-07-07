using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OffershiftrequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_OfferShiftRequests_OfferShiftRequestId: return $"/teams/{TeamId}/schedule/offerShiftRequests/{OfferShiftRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string TeamId { get; set; }
        public string OfferShiftRequestId { get; set; }
    }
    public partial class OffershiftrequestGetResponse : RestApiResponse
    {
        public DateTimeOffset? RecipientActionDateTime { get; set; }
        public string? RecipientActionMessage { get; set; }
        public string? RecipientUserId { get; set; }
        public string? SenderShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestGetResponse> OffershiftrequestGetAsync()
        {
            var p = new OffershiftrequestGetParameter();
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestGetResponse> OffershiftrequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new OffershiftrequestGetParameter();
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestGetResponse> OffershiftrequestGetAsync(OffershiftrequestGetParameter parameter)
        {
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestGetResponse> OffershiftrequestGetAsync(OffershiftrequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OffershiftrequestGetParameter, OffershiftrequestGetResponse>(parameter, cancellationToken);
        }
    }
}
