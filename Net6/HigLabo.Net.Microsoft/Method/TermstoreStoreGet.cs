using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreStoreGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore: return $"/ites/{SiteId}/termStore";
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
        public string SiteId { get; set; }
    }
    public partial class TermstoreStoreGetResponse : RestApiResponse
    {
        public string? DefaultLanguageTag { get; set; }
        public string? Id { get; set; }
        public String[]? LanguageTags { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreStoreGetResponse> TermstoreStoreGetAsync()
        {
            var p = new TermstoreStoreGetParameter();
            return await this.SendAsync<TermstoreStoreGetParameter, TermstoreStoreGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreStoreGetResponse> TermstoreStoreGetAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreStoreGetParameter();
            return await this.SendAsync<TermstoreStoreGetParameter, TermstoreStoreGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreStoreGetResponse> TermstoreStoreGetAsync(TermstoreStoreGetParameter parameter)
        {
            return await this.SendAsync<TermstoreStoreGetParameter, TermstoreStoreGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreStoreGetResponse> TermstoreStoreGetAsync(TermstoreStoreGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreStoreGetParameter, TermstoreStoreGetResponse>(parameter, cancellationToken);
        }
    }
}
