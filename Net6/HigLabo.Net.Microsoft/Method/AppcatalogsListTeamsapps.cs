using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AppcatalogsListTeamsappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class AppcatalogsListTeamsappsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? ExternalId { get; set; }
        public string? DisplayName { get; set; }
        public TeamsAppDistributionMethod? DistributionMethod { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async Task<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync()
        {
            var p = new AppcatalogsListTeamsappsParameter();
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async Task<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync(CancellationToken cancellationToken)
        {
            var p = new AppcatalogsListTeamsappsParameter();
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async Task<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync(AppcatalogsListTeamsappsParameter parameter)
        {
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async Task<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync(AppcatalogsListTeamsappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(parameter, cancellationToken);
        }
    }
}
