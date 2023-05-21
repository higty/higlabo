using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class ListListContentTypesParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes: return $"/sites/{SiteId}/lists/{ListId}/contentTypes";
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
            Sites_SiteId_Lists_ListId_ContentTypes,
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
    public partial class ListListContentTypesResponse : RestApiResponse
    {
        public ContentType[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContentTypesResponse> ListListContentTypesAsync()
        {
            var p = new ListListContentTypesParameter();
            return await this.SendAsync<ListListContentTypesParameter, ListListContentTypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContentTypesResponse> ListListContentTypesAsync(CancellationToken cancellationToken)
        {
            var p = new ListListContentTypesParameter();
            return await this.SendAsync<ListListContentTypesParameter, ListListContentTypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContentTypesResponse> ListListContentTypesAsync(ListListContentTypesParameter parameter)
        {
            return await this.SendAsync<ListListContentTypesParameter, ListListContentTypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListContentTypesResponse> ListListContentTypesAsync(ListListContentTypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListListContentTypesParameter, ListListContentTypesResponse>(parameter, cancellationToken);
        }
    }
}
