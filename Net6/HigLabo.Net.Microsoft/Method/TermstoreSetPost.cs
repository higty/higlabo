using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreSetPostParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets: return $"/ites/{SiteId}/termStore/sets";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TermStoreLocalizedName[]? LocalizedNames { get; set; }
        public Group? ParentGroup { get; set; }
        public string SiteId { get; set; }
    }
    public partial class TermstoreSetPostResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedName[]? LocalizedNames { get; set; }
        public KeyValue[]? Properties { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetPostResponse> TermstoreSetPostAsync()
        {
            var p = new TermstoreSetPostParameter();
            return await this.SendAsync<TermstoreSetPostParameter, TermstoreSetPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetPostResponse> TermstoreSetPostAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreSetPostParameter();
            return await this.SendAsync<TermstoreSetPostParameter, TermstoreSetPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetPostResponse> TermstoreSetPostAsync(TermstoreSetPostParameter parameter)
        {
            return await this.SendAsync<TermstoreSetPostParameter, TermstoreSetPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreSetPostResponse> TermstoreSetPostAsync(TermstoreSetPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreSetPostParameter, TermstoreSetPostResponse>(parameter, cancellationToken);
        }
    }
}
