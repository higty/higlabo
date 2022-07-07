using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypePublishParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_Publish,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Publish: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/publish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string SiteId { get; set; }
        public string ContentTypeId { get; set; }
    }
    public partial class ContenttypePublishResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePublishResponse> ContenttypePublishAsync()
        {
            var p = new ContenttypePublishParameter();
            return await this.SendAsync<ContenttypePublishParameter, ContenttypePublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePublishResponse> ContenttypePublishAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypePublishParameter();
            return await this.SendAsync<ContenttypePublishParameter, ContenttypePublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePublishResponse> ContenttypePublishAsync(ContenttypePublishParameter parameter)
        {
            return await this.SendAsync<ContenttypePublishParameter, ContenttypePublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePublishResponse> ContenttypePublishAsync(ContenttypePublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypePublishParameter, ContenttypePublishResponse>(parameter, cancellationToken);
        }
    }
}
