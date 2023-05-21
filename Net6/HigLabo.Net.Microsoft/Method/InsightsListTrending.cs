using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/insights-list-trending?view=graph-rest-1.0
    /// </summary>
    public partial class InsightsListTrendingParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Insights_Trending: return $"/me/insights/trending";
                    case ApiPath.Users_IdOrUserPrincipalName_Insights_Trending: return $"/users/{IdOrUserPrincipalName}/insights/trending";
                    case ApiPath.Me_Insights_Trending_Id_Resource: return $"/me/insights/trending/{Id}/resource";
                    case ApiPath.Users_IdOrUserPrincipalName_Insights_Trending_Id_Resource: return $"/users/{IdOrUserPrincipalName}/insights/trending/{Id}/resource";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Insights_Trending,
            Users_IdOrUserPrincipalName_Insights_Trending,
            Me_Insights_Trending_Id_Resource,
            Users_IdOrUserPrincipalName_Insights_Trending_Id_Resource,
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
    public partial class InsightsListTrendingResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public ResourceReference? ResourceReference { get; set; }
        public ResourceVisualization? ResourceVisualization { get; set; }
        public Double? Weight { get; set; }
        public Entity? Resource { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/insights-list-trending?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/insights-list-trending?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListTrendingResponse> InsightsListTrendingAsync()
        {
            var p = new InsightsListTrendingParameter();
            return await this.SendAsync<InsightsListTrendingParameter, InsightsListTrendingResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/insights-list-trending?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListTrendingResponse> InsightsListTrendingAsync(CancellationToken cancellationToken)
        {
            var p = new InsightsListTrendingParameter();
            return await this.SendAsync<InsightsListTrendingParameter, InsightsListTrendingResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/insights-list-trending?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListTrendingResponse> InsightsListTrendingAsync(InsightsListTrendingParameter parameter)
        {
            return await this.SendAsync<InsightsListTrendingParameter, InsightsListTrendingResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/insights-list-trending?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListTrendingResponse> InsightsListTrendingAsync(InsightsListTrendingParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InsightsListTrendingParameter, InsightsListTrendingResponse>(parameter, cancellationToken);
        }
    }
}
