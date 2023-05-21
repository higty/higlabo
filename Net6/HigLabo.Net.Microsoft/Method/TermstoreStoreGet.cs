using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreStoreGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_TermStore: return $"/sites/{SiteId}/termStore";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DefaultLanguageTag,
            Id,
            LanguageTags,
            Groups,
            Sets,
        }
        public enum ApiPath
        {
            Sites_SiteId_TermStore,
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
    public partial class TermStoreStoreGetResponse : RestApiResponse
    {
        public string? DefaultLanguageTag { get; set; }
        public string? Id { get; set; }
        public String[]? LanguageTags { get; set; }
        public TermStoreGroup[]? Groups { get; set; }
        public TermStoreSet[]? Sets { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreGetResponse> TermStoreStoreGetAsync()
        {
            var p = new TermStoreStoreGetParameter();
            return await this.SendAsync<TermStoreStoreGetParameter, TermStoreStoreGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreGetResponse> TermStoreStoreGetAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreStoreGetParameter();
            return await this.SendAsync<TermStoreStoreGetParameter, TermStoreStoreGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreGetResponse> TermStoreStoreGetAsync(TermStoreStoreGetParameter parameter)
        {
            return await this.SendAsync<TermStoreStoreGetParameter, TermStoreStoreGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-store-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreStoreGetResponse> TermStoreStoreGetAsync(TermStoreStoreGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreStoreGetParameter, TermStoreStoreGetResponse>(parameter, cancellationToken);
        }
    }
}
