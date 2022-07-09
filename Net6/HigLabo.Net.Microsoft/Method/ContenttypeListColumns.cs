using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContentTypeListColumnsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Columns: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/columns";
                    case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/{ContentTypeId}/columns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ColumnGroup,
            Description,
            DisplayName,
            EnforceUniqueValues,
            Hidden,
            Id,
            Indexed,
            Name,
            ReadOnly,
            Required,
            Boolean,
            Calculated,
            Choice,
            Currency,
            DateTime,
            DefaultValue,
            Geolocation,
            Lookup,
            Number,
            PersonOrGroup,
            Text,
            IsDeletable,
            PropagateChanges,
            IsReorderable,
            IsSealed,
            Validation,
            HyperlinkOrPicture,
            Term,
            SourceContentType,
            Thumbnail,
            Type,
            ContentApprovalStatus,
            SourceColumn,
        }
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_Columns,
            Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns,
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
    public partial class ContentTypeListColumnsResponse : RestApiResponse
    {
        public ColumnDefinition[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeListColumnsResponse> ContentTypeListColumnsAsync()
        {
            var p = new ContentTypeListColumnsParameter();
            return await this.SendAsync<ContentTypeListColumnsParameter, ContentTypeListColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeListColumnsResponse> ContentTypeListColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeListColumnsParameter();
            return await this.SendAsync<ContentTypeListColumnsParameter, ContentTypeListColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeListColumnsResponse> ContentTypeListColumnsAsync(ContentTypeListColumnsParameter parameter)
        {
            return await this.SendAsync<ContentTypeListColumnsParameter, ContentTypeListColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeListColumnsResponse> ContentTypeListColumnsAsync(ContentTypeListColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeListColumnsParameter, ContentTypeListColumnsResponse>(parameter, cancellationToken);
        }
    }
}
