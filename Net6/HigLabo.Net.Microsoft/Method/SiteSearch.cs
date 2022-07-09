using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
            Id,
            CreatedDateTime,
            Description,
            DisplayName,
            ETag,
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync()
        {
            var p = new SiteSearchParameter();
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync(CancellationToken cancellationToken)
        {
            var p = new SiteSearchParameter();
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter)
        {
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-search?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteSearchResponse> SiteSearchAsync(SiteSearchParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteSearchParameter, SiteSearchResponse>(parameter, cancellationToken);
        }
    }
}
