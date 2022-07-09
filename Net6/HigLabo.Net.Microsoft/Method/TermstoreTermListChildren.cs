using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermStoreTermListChildrenParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? SetId { get; set; }
            public string? TermId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Children: return $"/ites/{SiteId}/termStore/sets/{SetId}/children";
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/children";
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
            Ites_SiteId_TermStore_Sets_SetId_Children,
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children,
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
    public partial class TermStoreTermListChildrenResponse : RestApiResponse
    {
        public TermStoreTerm[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync()
        {
            var p = new TermStoreTermListChildrenParameter();
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreTermListChildrenParameter();
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync(TermStoreTermListChildrenParameter parameter)
        {
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync(TermStoreTermListChildrenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(parameter, cancellationToken);
        }
    }
}
