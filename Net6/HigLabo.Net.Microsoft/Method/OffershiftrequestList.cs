using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OffershiftrequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Schedule_OfferShiftRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Schedule_OfferShiftRequests: return $"/teams/{TeamId}/schedule/offerShiftRequests";
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
    }
    public partial class OffershiftrequestListResponse : RestApiResponse
    {
        public DateTimeOffset? RecipientActionDateTime { get; set; }
        public string? RecipientActionMessage { get; set; }
        public string? RecipientUserId { get; set; }
        public string? SenderShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestListResponse> OffershiftrequestListAsync()
        {
            var p = new OffershiftrequestListParameter();
            return await this.SendAsync<OffershiftrequestListParameter, OffershiftrequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestListResponse> OffershiftrequestListAsync(CancellationToken cancellationToken)
        {
            var p = new OffershiftrequestListParameter();
            return await this.SendAsync<OffershiftrequestListParameter, OffershiftrequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestListResponse> OffershiftrequestListAsync(OffershiftrequestListParameter parameter)
        {
            return await this.SendAsync<OffershiftrequestListParameter, OffershiftrequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestListResponse> OffershiftrequestListAsync(OffershiftrequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OffershiftrequestListParameter, OffershiftrequestListResponse>(parameter, cancellationToken);
        }
    }
}
