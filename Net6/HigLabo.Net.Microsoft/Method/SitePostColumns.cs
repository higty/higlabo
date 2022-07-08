using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SitePostColumnsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Columns: return $"/sites/{SiteId}/columns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Columns,
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
        public GeoLocationColumn? Geolocation { get; set; }
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
        public ColumnDefinition? SourceColumn { get; set; }
    }
    public partial class SitePostColumnsResponse : RestApiResponse
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
        public GeoLocationColumn? Geolocation { get; set; }
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
        public ColumnDefinition? SourceColumn { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostColumnsResponse> SitePostColumnsAsync()
        {
            var p = new SitePostColumnsParameter();
            return await this.SendAsync<SitePostColumnsParameter, SitePostColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostColumnsResponse> SitePostColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new SitePostColumnsParameter();
            return await this.SendAsync<SitePostColumnsParameter, SitePostColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostColumnsResponse> SitePostColumnsAsync(SitePostColumnsParameter parameter)
        {
            return await this.SendAsync<SitePostColumnsParameter, SitePostColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-post-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SitePostColumnsResponse> SitePostColumnsAsync(SitePostColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SitePostColumnsParameter, SitePostColumnsResponse>(parameter, cancellationToken);
        }
    }
}
