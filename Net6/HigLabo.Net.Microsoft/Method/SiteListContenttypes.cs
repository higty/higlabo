using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListContentTypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_ContentTypes: return $"/sites/{SiteId}/contentTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AssociatedHubsUrls,
            Description,
            DocumentSet,
            DocumentTemplate,
            Group,
            Hidden,
            Id,
            InheritedFrom,
            IsBuiltIn,
            Name,
            Order,
            ParentId,
            PropagateChanges,
            ReadOnly,
            Sealed,
            Base,
            ColumnLinks,
            BaseTypes,
            ColumnPositions,
            Columns,
        }
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes,
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
    public partial class SiteListContentTypesResponse : RestApiResponse
    {
        public ContentType[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContentTypesResponse> SiteListContentTypesAsync()
        {
            var p = new SiteListContentTypesParameter();
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContentTypesResponse> SiteListContentTypesAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListContentTypesParameter();
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContentTypesResponse> SiteListContentTypesAsync(SiteListContentTypesParameter parameter)
        {
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListContentTypesResponse> SiteListContentTypesAsync(SiteListContentTypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(parameter, cancellationToken);
        }
    }
}
