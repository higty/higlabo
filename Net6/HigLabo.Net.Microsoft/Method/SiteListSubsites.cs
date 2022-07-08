using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SiteListSubsitesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Sites: return $"/sites/{SiteId}/sites";
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
            Sites_SiteId_Sites,
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
    public partial class SiteListSubsitesResponse : RestApiResponse
    {
        public Site[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync()
        {
            var p = new SiteListSubsitesParameter();
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListSubsitesParameter();
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync(SiteListSubsitesParameter parameter)
        {
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
        /// </summary>
        public async Task<SiteListSubsitesResponse> SiteListSubsitesAsync(SiteListSubsitesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(parameter, cancellationToken);
        }
    }
}
