using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermStoreSetGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }
            public string SetId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId: return $"/ites/{SiteId}/termStore/sets/{SetId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Description,
            Id,
            LocalizedNames,
            Properties,
            Children,
            ParentGroup,
            Relations,
            Terms,
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId,
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
    public partial class TermStoreSetGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedname[]? LocalizedNames { get; set; }
        public KeyValue[]? Properties { get; set; }
        public TermStoreTerm[]? Children { get; set; }
        public TermStoreGroup? ParentGroup { get; set; }
        public TermStoreRelation[]? Relations { get; set; }
        public TermStoreTerm[]? Terms { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetGetResponse> TermStoreSetGetAsync()
        {
            var p = new TermStoreSetGetParameter();
            return await this.SendAsync<TermStoreSetGetParameter, TermStoreSetGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetGetResponse> TermStoreSetGetAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreSetGetParameter();
            return await this.SendAsync<TermStoreSetGetParameter, TermStoreSetGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetGetResponse> TermStoreSetGetAsync(TermStoreSetGetParameter parameter)
        {
            return await this.SendAsync<TermStoreSetGetParameter, TermStoreSetGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-set-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreSetGetResponse> TermStoreSetGetAsync(TermStoreSetGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreSetGetParameter, TermStoreSetGetResponse>(parameter, cancellationToken);
        }
    }
}
