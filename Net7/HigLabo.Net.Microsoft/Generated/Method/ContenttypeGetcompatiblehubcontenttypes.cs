using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class ContentTypeGetcompatiblehubContentTypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_GetCompatibleHubContentTypes: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/getCompatibleHubContentTypes";
                    case ApiPath.Sites_SiteId_ContentTypes_GetCompatibleHubContentTypes: return $"/sites/{SiteId}/contentTypes/getCompatibleHubContentTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AssociatedHubsUrls,
            Description,
            DocumentSet,
            DocumentTemplate,
            Group,
            Hidden,
            Id,
            InheritedFrom,
            IsBuiltIn,
            Name,
            Order,
            ParentId,
            PropagateChanges,
            ReadOnly,
            Sealed,
            Base,
            ColumnLinks,
            BaseTypes,
            ColumnPositions,
            Columns,
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_ContentTypes_GetCompatibleHubContentTypes,
            Sites_SiteId_ContentTypes_GetCompatibleHubContentTypes,
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
    public partial class ContentTypeGetcompatiblehubContentTypesResponse : RestApiResponse
    {
        public ContentType[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeGetcompatiblehubContentTypesResponse> ContentTypeGetcompatiblehubContentTypesAsync()
        {
            var p = new ContentTypeGetcompatiblehubContentTypesParameter();
            return await this.SendAsync<ContentTypeGetcompatiblehubContentTypesParameter, ContentTypeGetcompatiblehubContentTypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeGetcompatiblehubContentTypesResponse> ContentTypeGetcompatiblehubContentTypesAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeGetcompatiblehubContentTypesParameter();
            return await this.SendAsync<ContentTypeGetcompatiblehubContentTypesParameter, ContentTypeGetcompatiblehubContentTypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeGetcompatiblehubContentTypesResponse> ContentTypeGetcompatiblehubContentTypesAsync(ContentTypeGetcompatiblehubContentTypesParameter parameter)
        {
            return await this.SendAsync<ContentTypeGetcompatiblehubContentTypesParameter, ContentTypeGetcompatiblehubContentTypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/contenttype-getcompatiblehubcontenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ContentTypeGetcompatiblehubContentTypesResponse> ContentTypeGetcompatiblehubContentTypesAsync(ContentTypeGetcompatiblehubContentTypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeGetcompatiblehubContentTypesParameter, ContentTypeGetcompatiblehubContentTypesResponse>(parameter, cancellationToken);
        }
    }
}
