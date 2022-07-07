using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListSubsitesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Sites,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_Sites: return $"/sites/{SiteId}/sites";
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
    public partial class SiteListSubsitesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync()
        {
            var p = new SiteListSubsitesParameter();
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListSubsitesParameter();
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync(SiteListSubsitesParameter parameter)
        {
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync(SiteListSubsitesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(parameter, cancellationToken);
        }
    }
}
