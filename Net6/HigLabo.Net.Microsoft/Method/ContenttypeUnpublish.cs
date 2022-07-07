using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeUnpublishParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_Unpublish,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Unpublish: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/unpublish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string SiteId { get; set; }
        public string ContentTypeId { get; set; }
    }
    public partial class ContenttypeUnpublishResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeUnpublishResponse> ContenttypeUnpublishAsync()
        {
            var p = new ContenttypeUnpublishParameter();
            return await this.SendAsync<ContenttypeUnpublishParameter, ContenttypeUnpublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeUnpublishResponse> ContenttypeUnpublishAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeUnpublishParameter();
            return await this.SendAsync<ContenttypeUnpublishParameter, ContenttypeUnpublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeUnpublishResponse> ContenttypeUnpublishAsync(ContenttypeUnpublishParameter parameter)
        {
            return await this.SendAsync<ContenttypeUnpublishParameter, ContenttypeUnpublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeUnpublishResponse> ContenttypeUnpublishAsync(ContenttypeUnpublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeUnpublishParameter, ContenttypeUnpublishResponse>(parameter, cancellationToken);
        }
    }
}
