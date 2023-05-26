using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
    /// </summary>
    public partial class ContentTypeDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ContentTypeId { get; set; }
            public string? ListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}";
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/{ContentTypeId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId,
            Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ContentTypeDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeDeleteResponse> ContentTypeDeleteAsync()
        {
            var p = new ContentTypeDeleteParameter();
            return await this.SendAsync<ContentTypeDeleteParameter, ContentTypeDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeDeleteResponse> ContentTypeDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeDeleteParameter();
            return await this.SendAsync<ContentTypeDeleteParameter, ContentTypeDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeDeleteResponse> ContentTypeDeleteAsync(ContentTypeDeleteParameter parameter)
        {
            return await this.SendAsync<ContentTypeDeleteParameter, ContentTypeDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeDeleteResponse> ContentTypeDeleteAsync(ContentTypeDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeDeleteParameter, ContentTypeDeleteResponse>(parameter, cancellationToken);
        }
    }
}
