using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypePostColumnsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_Columns,
            Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Columns: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/columns";
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/{ContentTypeId}/columns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string SiteId { get; set; }
        public string ContentTypeId { get; set; }
        public string ListId { get; set; }
    }
    public partial class ContenttypePostColumnsResponse : RestApiResponse
    {
        public string? ColumnGroup { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? EnforceUniqueValues { get; set; }
        public bool? Hidden { get; set; }
        public string? Id { get; set; }
        public bool? Indexed { get; set; }
        public string? Name { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Required { get; set; }
        public BooleanColumn? Boolean { get; set; }
        public CalculatedColumn? Calculated { get; set; }
        public ChoiceColumn? Choice { get; set; }
        public CurrencyColumn? Currency { get; set; }
        public DateTimeColumn? DateTime { get; set; }
        public DefaultColumnValue? DefaultValue { get; set; }
        public GeolocationColumn? Geolocation { get; set; }
        public LookupColumn? Lookup { get; set; }
        public NumberColumn? Number { get; set; }
        public PersonOrGroupColumn? PersonOrGroup { get; set; }
        public TextColumn? Text { get; set; }
        public bool? IsDeletable { get; set; }
        public bool? PropagateChanges { get; set; }
        public bool? IsReorderable { get; set; }
        public bool? IsSealed { get; set; }
        public ColumnValidation? Validation { get; set; }
        public HyperlinkOrPictureColumn? HyperlinkOrPicture { get; set; }
        public TermColumn? Term { get; set; }
        public ContentTypeInfo? SourceContentType { get; set; }
        public ThumbnailColumn? Thumbnail { get; set; }
        public string? Type { get; set; }
        public ContentApprovalStatusColumn? ContentApprovalStatus { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePostColumnsResponse> ContenttypePostColumnsAsync()
        {
            var p = new ContenttypePostColumnsParameter();
            return await this.SendAsync<ContenttypePostColumnsParameter, ContenttypePostColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePostColumnsResponse> ContenttypePostColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypePostColumnsParameter();
            return await this.SendAsync<ContenttypePostColumnsParameter, ContenttypePostColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePostColumnsResponse> ContenttypePostColumnsAsync(ContenttypePostColumnsParameter parameter)
        {
            return await this.SendAsync<ContenttypePostColumnsParameter, ContenttypePostColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypePostColumnsResponse> ContenttypePostColumnsAsync(ContenttypePostColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypePostColumnsParameter, ContenttypePostColumnsResponse>(parameter, cancellationToken);
        }
    }
}
