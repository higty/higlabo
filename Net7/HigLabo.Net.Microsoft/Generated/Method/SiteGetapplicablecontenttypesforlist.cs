using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
    /// </summary>
    public partial class SiteGetapplicableContentTypesforlistParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_GetApplicableContentTypesForList: return $"/sites/{SiteId}/getApplicableContentTypesForList";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Description,
            DisplayName,
            ETag,
            Id,
            LastModifiedDateTime,
            Name,
            Root,
            SharepointIds,
            SiteCollection,
            WebUrl,
            Analytics,
            Columns,
            ContentTypes,
            Drive,
            Drives,
            Items,
            Lists,
            Onenote,
            Operations,
            Permissions,
            Sites,
            TermStore,
            TermStores,
            AssociatedHubsUrls,
            DocumentSet,
            DocumentTemplate,
            Group,
            Hidden,
            InheritedFrom,
            IsBuiltIn,
            Order,
            ParentId,
            PropagateChanges,
            ReadOnly,
            Sealed,
            Base,
            ColumnLinks,
            BaseTypes,
            ColumnPositions,
        }
        public enum ApiPath
        {
            Sites_SiteId_GetApplicableContentTypesForList,
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
    public partial class SiteGetapplicableContentTypesforlistResponse : RestApiResponse
    {
        public ContentType[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteGetapplicableContentTypesforlistResponse> SiteGetapplicableContentTypesforlistAsync()
        {
            var p = new SiteGetapplicableContentTypesforlistParameter();
            return await this.SendAsync<SiteGetapplicableContentTypesforlistParameter, SiteGetapplicableContentTypesforlistResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteGetapplicableContentTypesforlistResponse> SiteGetapplicableContentTypesforlistAsync(CancellationToken cancellationToken)
        {
            var p = new SiteGetapplicableContentTypesforlistParameter();
            return await this.SendAsync<SiteGetapplicableContentTypesforlistParameter, SiteGetapplicableContentTypesforlistResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteGetapplicableContentTypesforlistResponse> SiteGetapplicableContentTypesforlistAsync(SiteGetapplicableContentTypesforlistParameter parameter)
        {
            return await this.SendAsync<SiteGetapplicableContentTypesforlistParameter, SiteGetapplicableContentTypesforlistResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-getapplicablecontenttypesforlist?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteGetapplicableContentTypesforlistResponse> SiteGetapplicableContentTypesforlistAsync(SiteGetapplicableContentTypesforlistParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteGetapplicableContentTypesforlistParameter, SiteGetapplicableContentTypesforlistResponse>(parameter, cancellationToken);
        }
    }
}
