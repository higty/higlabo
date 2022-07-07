using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeIspublishedParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_IsPublished,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_IsPublished: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/isPublished";
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
        public string ContentTypeId { get; set; }
    }
    public partial class ContenttypeIspublishedResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeIspublishedResponse> ContenttypeIspublishedAsync()
        {
            var p = new ContenttypeIspublishedParameter();
            return await this.SendAsync<ContenttypeIspublishedParameter, ContenttypeIspublishedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeIspublishedResponse> ContenttypeIspublishedAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeIspublishedParameter();
            return await this.SendAsync<ContenttypeIspublishedParameter, ContenttypeIspublishedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeIspublishedResponse> ContenttypeIspublishedAsync(ContenttypeIspublishedParameter parameter)
        {
            return await this.SendAsync<ContenttypeIspublishedParameter, ContenttypeIspublishedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeIspublishedResponse> ContenttypeIspublishedAsync(ContenttypeIspublishedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeIspublishedParameter, ContenttypeIspublishedResponse>(parameter, cancellationToken);
        }
    }
}
