using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreTermListRelationsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Relations: return $"/sites/{SiteId}/termStore/sets/{SetId}/relations";
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations: return $"/sites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/relations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Relationship,
            FromTerm,
            Set,
            ToTerm,
        }
        public enum ApiPath
        {
            Sites_SiteId_TermStore_Sets_SetId_Relations,
            Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations,
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
    public partial class TermStoreTermListRelationsResponse : RestApiResponse
    {
        public TermStoreRelation[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync()
        {
            var p = new TermStoreTermListRelationsParameter();
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreTermListRelationsParameter();
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync(TermStoreTermListRelationsParameter parameter)
        {
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync(TermStoreTermListRelationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(parameter, cancellationToken);
        }
    }
}
