
namespace HigLabo.Net.Slack
{
    public class SearchFilesParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "search.files";
        public string HttpMethod { get; private set; } = "GET";
        public string Query { get; set; } = "";
        public int? Count { get; set; }
        public bool? Highlight { get; set; }
        public int? Page { get; set; }
        public Sort Sort { get; set; }
        public SortDirection Sort_Dir { get; set; }
        public string Team_Id { get; set; } = "";
    }
    public partial class SearchFilesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<SearchFilesResponse> SearchFilesAsync(string query)
        {
            var p = new SearchFilesParameter();
            p.Query = query;
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(p, CancellationToken.None);
        }
        public async Task<SearchFilesResponse> SearchFilesAsync(string query, CancellationToken cancellationToken)
        {
            var p = new SearchFilesParameter();
            p.Query = query;
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(p, cancellationToken);
        }
        public async Task<SearchFilesResponse> SearchFilesAsync(SearchFilesParameter parameter)
        {
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(parameter, CancellationToken.None);
        }
        public async Task<SearchFilesResponse> SearchFilesAsync(SearchFilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SearchFilesParameter, SearchFilesResponse>(parameter, cancellationToken);
        }
    }
}
