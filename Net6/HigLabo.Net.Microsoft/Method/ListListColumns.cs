using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ListListColumnsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ListListColumnsResponse : RestApiResponse
    {
        public ColumnDefinition[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListColumnsResponse> ListListColumnsAsync()
        {
            var p = new ListListColumnsParameter();
            return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListColumnsResponse> ListListColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new ListListColumnsParameter();
            return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListColumnsResponse> ListListColumnsAsync(ListListColumnsParameter parameter)
        {
            return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/list-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<ListListColumnsResponse> ListListColumnsAsync(ListListColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListListColumnsParameter, ListListColumnsResponse>(parameter, cancellationToken);
        }
    }
}
