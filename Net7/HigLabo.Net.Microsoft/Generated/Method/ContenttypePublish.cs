using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
    /// </summary>
    public partial class ContentTypePublishParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ContentTypeId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Publish: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/publish";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_Publish,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ContentTypePublishResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypePublishResponse> ContentTypePublishAsync()
        {
            var p = new ContentTypePublishParameter();
            return await this.SendAsync<ContentTypePublishParameter, ContentTypePublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypePublishResponse> ContentTypePublishAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypePublishParameter();
            return await this.SendAsync<ContentTypePublishParameter, ContentTypePublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypePublishResponse> ContentTypePublishAsync(ContentTypePublishParameter parameter)
        {
            return await this.SendAsync<ContentTypePublishParameter, ContentTypePublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-publish?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypePublishResponse> ContentTypePublishAsync(ContentTypePublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypePublishParameter, ContentTypePublishResponse>(parameter, cancellationToken);
        }
    }
}
