using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
    /// </summary>
    public partial class SiteListColumnsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Columns: return $"/sites/{SiteId}/columns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Boolean,
            Calculated,
            Choice,
            ColumnGroup,
            ContentApprovalStatus,
            Currency,
            DateTime,
            DefaultValue,
            Description,
            DisplayName,
            EnforceUniqueValues,
            Geolocation,
            Hidden,
            HyperlinkOrPicture,
            IsDeletable,
            IsReorderable,
            Id,
            Indexed,
            IsSealed,
            Lookup,
            Name,
            Number,
            PersonOrGroup,
            PropagateChanges,
            ReadOnly,
            Required,
            SourceContentType,
            Term,
            Text,
            Thumbnail,
            Type,
            Validation,
            SourceColumn,
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
    public partial class SiteListColumnsResponse : RestApiResponse
    {
        public ColumnDefinition[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListColumnsResponse> SiteListColumnsAsync()
        {
            var p = new SiteListColumnsParameter();
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListColumnsResponse> SiteListColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListColumnsParameter();
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListColumnsResponse> SiteListColumnsAsync(SiteListColumnsParameter parameter)
        {
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListColumnsResponse> SiteListColumnsAsync(SiteListColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(parameter, cancellationToken);
        }
    }
}
