using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
    /// </summary>
    public partial class SiteSearchParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites: return $"/sites";
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
        }
        public enum ApiPath
        {
            Sites,
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
    public partial class SiteSearchResponse : RestApiResponse
    {
        public Site[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteSearchResponse> SiteSearchAsync()
        {
            var p = new SiteSearchParameter();
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteSearchResponse> SiteSearchAsync(CancellationToken cancellationToken)
        {
            var p = new SiteSearchParameter();
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter)
        {
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, cancellationToken);
        }
    }
}
