using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-get?view=graph-rest-1.0
    /// </summary>
    public partial class DocumentsetversionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }
            public string? ItemId { get; set; }
            public string? DocumentSetVersionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions_DocumentSetVersionId: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/documentSetVersions/{DocumentSetVersionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Items_ItemId_DocumentSetVersions_DocumentSetVersionId,
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
    public partial class DocumentsetversionGetResponse : RestApiResponse
    {
        public string? Comment { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DocumentSetVersionItem[]? Items { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public TimeStamp? LastModifiedDateTime { get; set; }
        public PublicationFacet? Published { get; set; }
        public bool? ShouldCaptureMinorVersion { get; set; }
        public FieldValueSet? Fields { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionGetResponse> DocumentsetversionGetAsync()
        {
            var p = new DocumentsetversionGetParameter();
            return await this.SendAsync<DocumentsetversionGetParameter, DocumentsetversionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionGetResponse> DocumentsetversionGetAsync(CancellationToken cancellationToken)
        {
            var p = new DocumentsetversionGetParameter();
            return await this.SendAsync<DocumentsetversionGetParameter, DocumentsetversionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionGetResponse> DocumentsetversionGetAsync(DocumentsetversionGetParameter parameter)
        {
            return await this.SendAsync<DocumentsetversionGetParameter, DocumentsetversionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/documentsetversion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DocumentsetversionGetResponse> DocumentsetversionGetAsync(DocumentsetversionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DocumentsetversionGetParameter, DocumentsetversionGetResponse>(parameter, cancellationToken);
        }
    }
}
