using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamsappPublishParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            AppCatalogs_TeamsApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.AppCatalogs_TeamsApps: return $"/appCatalogs/teamsApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class TeamsappPublishResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? ExternalId { get; set; }
        public string? DisplayName { get; set; }
        public TeamsAppDistributionMethod? DistributionMethod { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappPublishResponse> TeamsappPublishAsync()
        {
            var p = new TeamsappPublishParameter();
            return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappPublishResponse> TeamsappPublishAsync(CancellationToken cancellationToken)
        {
            var p = new TeamsappPublishParameter();
            return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappPublishResponse> TeamsappPublishAsync(TeamsappPublishParameter parameter)
        {
            return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappPublishResponse> TeamsappPublishAsync(TeamsappPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamsappPublishParameter, TeamsappPublishResponse>(parameter, cancellationToken);
        }
    }
}
