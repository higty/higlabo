using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
    /// </summary>
    public partial class ContentTypeIspublishedParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_IsPublished: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/isPublished";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_IsPublished,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class ContentTypeIspublishedResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeIspublishedResponse> ContentTypeIspublishedAsync()
        {
            var p = new ContentTypeIspublishedParameter();
            return await this.SendAsync<ContentTypeIspublishedParameter, ContentTypeIspublishedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeIspublishedResponse> ContentTypeIspublishedAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeIspublishedParameter();
            return await this.SendAsync<ContentTypeIspublishedParameter, ContentTypeIspublishedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeIspublishedResponse> ContentTypeIspublishedAsync(ContentTypeIspublishedParameter parameter)
        {
            return await this.SendAsync<ContentTypeIspublishedParameter, ContentTypeIspublishedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-ispublished?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeIspublishedResponse> ContentTypeIspublishedAsync(ContentTypeIspublishedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeIspublishedParameter, ContentTypeIspublishedResponse>(parameter, cancellationToken);
        }
    }
}
