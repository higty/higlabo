using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteSearchParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites: return $"/sites";
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
    public partial class SiteSearchResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/site?view=graph-rest-1.0
        /// </summary>
        public partial class Site
        {
            public string? Id { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? ETag { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public Root? Root { get; set; }
            public SharePointIds? SharepointIds { get; set; }
            public SiteCollection? SiteCollection { get; set; }
            public string? WebUrl { get; set; }
        }

        public Site[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync()
        {
            var p = new SiteSearchParameter();
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync(CancellationToken cancellationToken)
        {
            var p = new SiteSearchParameter();
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter)
        {
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, cancellationToken);
        }
    }
}
