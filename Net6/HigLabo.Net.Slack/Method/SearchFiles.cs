using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class SearchFilesParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "search.files";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Query { get; set; }
        public int? Count { get; set; }
        public bool? Highlight { get; set; }
        public int? Page { get; set; }
        public Sort Sort { get; set; }
        public SortDirection Sort_Dir { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class SearchFilesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/search.files
        /// </summary>
        public async Task<SearchFilesResponse> SearchFilesAsync(string? query)
        {
            var p = new SearchFilesParameter();
            p.Query = query;
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/search.files
        /// </summary>
        public async Task<SearchFilesResponse> SearchFilesAsync(string? query, CancellationToken cancellationToken)
        {
            var p = new SearchFilesParameter();
            p.Query = query;
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/search.files
        /// </summary>
        public async Task<SearchFilesResponse> SearchFilesAsync(SearchFilesParameter parameter)
        {
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/search.files
        /// </summary>
        public async Task<SearchFilesResponse> SearchFilesAsync(SearchFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(parameter, cancellationToken);
        }
    }
}
