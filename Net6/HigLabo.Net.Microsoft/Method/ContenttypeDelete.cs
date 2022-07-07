using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId,
            Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}";
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/{ContentTypeId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SiteId { get; set; }
        public string ContentTypeId { get; set; }
        public string ListId { get; set; }
    }
    public partial class ContenttypeDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeDeleteResponse> ContenttypeDeleteAsync()
        {
            var p = new ContenttypeDeleteParameter();
            return await this.SendAsync<ContenttypeDeleteParameter, ContenttypeDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeDeleteResponse> ContenttypeDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeDeleteParameter();
            return await this.SendAsync<ContenttypeDeleteParameter, ContenttypeDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeDeleteResponse> ContenttypeDeleteAsync(ContenttypeDeleteParameter parameter)
        {
            return await this.SendAsync<ContenttypeDeleteParameter, ContenttypeDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeDeleteResponse> ContenttypeDeleteAsync(ContenttypeDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeDeleteParameter, ContenttypeDeleteResponse>(parameter, cancellationToken);
        }
    }
}
