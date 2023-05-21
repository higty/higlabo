using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public partial class ListitemListDocumentsetversionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }
            public string? ItemId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/documentSetVersions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Comment,
            CreatedBy,
            CreatedDateTime,
            Id,
            Items,
            LastModifiedBy,
            LastModifiedDateTime,
            Published,
            ShouldCaptureMinorVersion,
            Fields,
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions,
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
    public partial class ListitemListDocumentsetversionsResponse : RestApiResponse
    {
        public DocumentSetVersion[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListDocumentsetversionsResponse> ListitemListDocumentsetversionsAsync()
        {
            var p = new ListitemListDocumentsetversionsParameter();
            return await this.SendAsync<ListitemListDocumentsetversionsParameter, ListitemListDocumentsetversionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListDocumentsetversionsResponse> ListitemListDocumentsetversionsAsync(CancellationToken cancellationToken)
        {
            var p = new ListitemListDocumentsetversionsParameter();
            return await this.SendAsync<ListitemListDocumentsetversionsParameter, ListitemListDocumentsetversionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListDocumentsetversionsResponse> ListitemListDocumentsetversionsAsync(ListitemListDocumentsetversionsParameter parameter)
        {
            return await this.SendAsync<ListitemListDocumentsetversionsParameter, ListitemListDocumentsetversionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-list-documentsetversions?view=graph-rest-1.0
        /// </summary>
        public async Task<ListitemListDocumentsetversionsResponse> ListitemListDocumentsetversionsAsync(ListitemListDocumentsetversionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListitemListDocumentsetversionsParameter, ListitemListDocumentsetversionsResponse>(parameter, cancellationToken);
        }
    }
}
