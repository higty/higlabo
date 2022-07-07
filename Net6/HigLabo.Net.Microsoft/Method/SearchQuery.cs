using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SearchQueryParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Search_Query,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Search_Query: return $"/search/query";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public SearchRequest[]? Requests { get; set; }
    }
    public partial class SearchQueryResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/searchresponse?view=graph-rest-1.0
        /// </summary>
        public partial class SearchResponse
        {
            public SearchHitsContainer[]? HitsContainers { get; set; }
            public ResultTemplate[]? ResultTemplates { get; set; }
            public String[]? SearchTerms { get; set; }
            public AlterationResponse? QueryAlterationResponse { get; set; }
        }

        public SearchResponse[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async Task<SearchQueryResponse> SearchQueryAsync()
        {
            var p = new SearchQueryParameter();
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async Task<SearchQueryResponse> SearchQueryAsync(CancellationToken cancellationToken)
        {
            var p = new SearchQueryParameter();
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async Task<SearchQueryResponse> SearchQueryAsync(SearchQueryParameter parameter)
        {
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/search-query?view=graph-rest-1.0
        /// </summary>
        public async Task<SearchQueryResponse> SearchQueryAsync(SearchQueryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SearchQueryParameter, SearchQueryResponse>(parameter, cancellationToken);
        }
    }
}
