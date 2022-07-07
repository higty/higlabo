using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OffershiftrequestPostParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
    }
    public partial class OffershiftrequestPostResponse : RestApiResponse
    {
        public DateTimeOffset? RecipientActionDateTime { get; set; }
        public string? RecipientActionMessage { get; set; }
        public string? RecipientUserId { get; set; }
        public string? SenderShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestPostResponse> OffershiftrequestPostAsync()
        {
            var p = new OffershiftrequestPostParameter();
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestPostResponse> OffershiftrequestPostAsync(CancellationToken cancellationToken)
        {
            var p = new OffershiftrequestPostParameter();
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestPostResponse> OffershiftrequestPostAsync(OffershiftrequestPostParameter parameter)
        {
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OffershiftrequestPostResponse> OffershiftrequestPostAsync(OffershiftrequestPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(parameter, cancellationToken);
        }
    }
}
