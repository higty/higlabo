using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListPostColumnsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Columns,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_Columns: return $"/sites/{SiteId}/lists/{ListId}/columns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string SiteId { get; set; }
        public string ListId { get; set; }
    }
    public partial class ListPostColumnsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync()
        {
            var p = new ListPostColumnsParameter();
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new ListPostColumnsParameter();
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync(ListPostColumnsParameter parameter)
        {
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync(ListPostColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(parameter, cancellationToken);
        }
    }
}
