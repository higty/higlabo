using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Content,
            ContentUrl,
            CreatedByAppId,
            CreatedDateTime,
            Id,
            LastModifiedDateTime,
            Level,
            Links,
            Order,
            Self,
            Title,
        }
        public enum ApiPath
        {
            Me_Onenote_Pages_Id,
            Users_IdOrUserPrincipalName_Onenote_Pages_Id,
            Groups_Id_Onenote_Pages_Id,
            Sites_Id_Onenote_Pages_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Pages_Id: return $"/me/onenote/pages/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages_Id: return $"/users/{IdOrUserPrincipalName}/onenote/pages/{Id}";
                    case ApiPath.Groups_Id_Onenote_Pages_Id: return $"/groups/{GroupsId}/onenote/pages/{PagesId}";
                    case ApiPath.Sites_Id_Onenote_Pages_Id: return $"/sites/{SitesId}/onenote/pages/{PagesId}";
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
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string PagesId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class PageGetResponse : RestApiResponse
    {
        public Stream? Content { get; set; }
        public string? ContentUrl { get; set; }
        public string? CreatedByAppId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Level { get; set; }
        public PageLinks? Links { get; set; }
        public Int32? Order { get; set; }
        public string? Self { get; set; }
        public string? Title { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PageGetResponse> PageGetAsync()
        {
            var p = new PageGetParameter();
            return await this.SendAsync<PageGetParameter, PageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PageGetResponse> PageGetAsync(CancellationToken cancellationToken)
        {
            var p = new PageGetParameter();
            return await this.SendAsync<PageGetParameter, PageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PageGetResponse> PageGetAsync(PageGetParameter parameter)
        {
            return await this.SendAsync<PageGetParameter, PageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/page-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PageGetResponse> PageGetAsync(PageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PageGetParameter, PageGetResponse>(parameter, cancellationToken);
        }
    }
}
