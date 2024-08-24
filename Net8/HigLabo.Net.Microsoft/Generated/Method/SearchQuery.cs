using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
    /// </summary>
    public partial class SearchQueryParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Search_Query: return $"/search/query";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Search_Query,
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
        public SearchRequest[]? Requests { get; set; }
    }
    public partial class SearchQueryResponse : RestApiResponse<SearchResponse>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SearchQueryResponse> SearchQueryAsync()
        {
            var p = new SearchQueryParameter();
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SearchQueryResponse> SearchQueryAsync(CancellationToken cancellationToken)
        {
            var p = new SearchQueryParameter();
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SearchQueryResponse> SearchQueryAsync(SearchQueryParameter parameter)
        {
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SearchQueryResponse> SearchQueryAsync(SearchQueryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(parameter, cancellationToken);
        }
    }
}
