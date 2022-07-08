using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermStoreTermGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string SiteId { get; set; }
            public string GroupId { get; set; }
            public string SetId { get; set; }
            public string TermId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ites_SiteId_TermStore_Groups_GroupId_Sets_SetId_Terms_TermId: return $"/ites/{SiteId}/termStore/groups/{GroupId}/sets/{SetId}/terms/{TermId}";
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Descriptions,
            Id,
            Labels,
            LastModifiedDateTime,
            Properties,
            Children,
            Relations,
            Set,
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Groups_GroupId_Sets_SetId_Terms_TermId,
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId,
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
    public partial class TermStoreTermGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TermStoreLocalizeddescription[]? Descriptions { get; set; }
        public string? Id { get; set; }
        public TermStoreLocalizedlabel[]? Labels { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public KeyValue[]? Properties { get; set; }
        public TermStoreTerm[]? Children { get; set; }
        public TermStoreRelation[]? Relations { get; set; }
        public TermStoreSet? Set { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermGetResponse> TermStoreTermGetAsync()
        {
            var p = new TermStoreTermGetParameter();
            return await this.SendAsync<TermStoreTermGetParameter, TermStoreTermGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermGetResponse> TermStoreTermGetAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreTermGetParameter();
            return await this.SendAsync<TermStoreTermGetParameter, TermStoreTermGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermGetResponse> TermStoreTermGetAsync(TermStoreTermGetParameter parameter)
        {
            return await this.SendAsync<TermStoreTermGetParameter, TermStoreTermGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermGetResponse> TermStoreTermGetAsync(TermStoreTermGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreTermGetParameter, TermStoreTermGetResponse>(parameter, cancellationToken);
        }
    }
}
