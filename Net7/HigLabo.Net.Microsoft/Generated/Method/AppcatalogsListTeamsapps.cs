using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
    /// </summary>
    public partial class AppcatalogsListTeamsappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AppCatalogs_TeamsApps: return $"/appCatalogs/teamsApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            AppCatalogs_TeamsApps,
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
    public partial class AppcatalogsListTeamsappsResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public TeamsAppDistributionMethod? DistributionMethod { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public TeamsAppDefinition[]? AppDefinitions { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync()
        {
            var p = new AppcatalogsListTeamsappsParameter();
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync(CancellationToken cancellationToken)
        {
            var p = new AppcatalogsListTeamsappsParameter();
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync(AppcatalogsListTeamsappsParameter parameter)
        {
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appcatalogs-list-teamsapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppcatalogsListTeamsappsResponse> AppcatalogsListTeamsappsAsync(AppcatalogsListTeamsappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppcatalogsListTeamsappsParameter, AppcatalogsListTeamsappsResponse>(parameter, cancellationToken);
        }
    }
}
