using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
    /// </summary>
    public partial class ListPostColumnsParameter : IRestApiParameter
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
                    case ApiPath.Sites_SiteId_Lists_ListId_Columns: return $"/sites/{SiteId}/lists/{ListId}/columns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Columns,
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
        public BooleanColumn? Boolean { get; set; }
        public CalculatedColumn? Calculated { get; set; }
        public ChoiceColumn? Choice { get; set; }
        public string? ColumnGroup { get; set; }
        public ContentApprovalStatusColumn? ContentApprovalStatus { get; set; }
        public CurrencyColumn? Currency { get; set; }
        public DateTimeColumn? DateTime { get; set; }
        public DefaultColumnValue? DefaultValue { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? EnforceUniqueValues { get; set; }
        public GeoLocationColumn? Geolocation { get; set; }
        public bool? Hidden { get; set; }
        public HyperlinkOrPictureColumn? HyperlinkOrPicture { get; set; }
        public bool? IsDeletable { get; set; }
        public bool? IsReorderable { get; set; }
        public string? Id { get; set; }
        public bool? Indexed { get; set; }
        public bool? IsSealed { get; set; }
        public LookupColumn? Lookup { get; set; }
        public string? Name { get; set; }
        public NumberColumn? Number { get; set; }
        public PersonOrGroupColumn? PersonOrGroup { get; set; }
        public bool? PropagateChanges { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Required { get; set; }
        public ContentTypeInfo? SourceContentType { get; set; }
        public TermColumn? Term { get; set; }
        public TextColumn? Text { get; set; }
        public ThumbnailColumn? Thumbnail { get; set; }
        public string? Type { get; set; }
        public ColumnValidation? Validation { get; set; }
        public ColumnDefinition? SourceColumn { get; set; }
    }
    public partial class ListPostColumnsResponse : RestApiResponse
    {
        public BooleanColumn? Boolean { get; set; }
        public CalculatedColumn? Calculated { get; set; }
        public ChoiceColumn? Choice { get; set; }
        public string? ColumnGroup { get; set; }
        public ContentApprovalStatusColumn? ContentApprovalStatus { get; set; }
        public CurrencyColumn? Currency { get; set; }
        public DateTimeColumn? DateTime { get; set; }
        public DefaultColumnValue? DefaultValue { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? EnforceUniqueValues { get; set; }
        public GeoLocationColumn? Geolocation { get; set; }
        public bool? Hidden { get; set; }
        public HyperlinkOrPictureColumn? HyperlinkOrPicture { get; set; }
        public bool? IsDeletable { get; set; }
        public bool? IsReorderable { get; set; }
        public string? Id { get; set; }
        public bool? Indexed { get; set; }
        public bool? IsSealed { get; set; }
        public LookupColumn? Lookup { get; set; }
        public string? Name { get; set; }
        public NumberColumn? Number { get; set; }
        public PersonOrGroupColumn? PersonOrGroup { get; set; }
        public bool? PropagateChanges { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Required { get; set; }
        public ContentTypeInfo? SourceContentType { get; set; }
        public TermColumn? Term { get; set; }
        public TextColumn? Text { get; set; }
        public ThumbnailColumn? Thumbnail { get; set; }
        public string? Type { get; set; }
        public ColumnValidation? Validation { get; set; }
        public ColumnDefinition? SourceColumn { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync()
        {
            var p = new ListPostColumnsParameter();
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new ListPostColumnsParameter();
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync(ListPostColumnsParameter parameter)
        {
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/list-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListPostColumnsResponse> ListPostColumnsAsync(ListPostColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListPostColumnsParameter, ListPostColumnsResponse>(parameter, cancellationToken);
        }
    }
}
