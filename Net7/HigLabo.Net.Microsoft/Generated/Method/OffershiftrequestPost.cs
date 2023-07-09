using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
    /// </summary>
    public partial class OffershiftrequestPostParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DateTimeOffset? RecipientActionDateTime { get; set; }
        public string? RecipientActionMessage { get; set; }
        public string? RecipientUserId { get; set; }
        public string? SenderShiftId { get; set; }
    }
    public partial class OffershiftrequestPostResponse : RestApiResponse
    {
        public DateTimeOffset? RecipientActionDateTime { get; set; }
        public string? RecipientActionMessage { get; set; }
        public string? RecipientUserId { get; set; }
        public string? SenderShiftId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestPostResponse> OffershiftrequestPostAsync()
        {
            var p = new OffershiftrequestPostParameter();
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestPostResponse> OffershiftrequestPostAsync(CancellationToken cancellationToken)
        {
            var p = new OffershiftrequestPostParameter();
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestPostResponse> OffershiftrequestPostAsync(OffershiftrequestPostParameter parameter)
        {
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/offershiftrequest-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OffershiftrequestPostResponse> OffershiftrequestPostAsync(OffershiftrequestPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OffershiftrequestPostParameter, OffershiftrequestPostResponse>(parameter, cancellationToken);
        }
    }
}
