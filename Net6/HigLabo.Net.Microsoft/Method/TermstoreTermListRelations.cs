using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreTermListRelationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId_Relations,
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Relations: return $"/ites/{SiteId}/termStore/sets/{SetId}/relations";
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/relations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string SiteId { get; set; }
        public string SetId { get; set; }
        public string TermId { get; set; }
    }
    public partial class TermstoreTermListRelationsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-relation?view=graph-rest-1.0
        /// </summary>
        public partial class Relation
        {
            public enum RelationTermStoreRelationType
            {
                Pin,
                Reuse,
            }

            public string? Id { get; set; }
            public RelationTermStoreRelationType Relationship { get; set; }
        }

        public Relation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListRelationsResponse> TermstoreTermListRelationsAsync()
        {
            var p = new TermstoreTermListRelationsParameter();
            return await this.SendAsync<TermstoreTermListRelationsParameter, TermstoreTermListRelationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListRelationsResponse> TermstoreTermListRelationsAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreTermListRelationsParameter();
            return await this.SendAsync<TermstoreTermListRelationsParameter, TermstoreTermListRelationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListRelationsResponse> TermstoreTermListRelationsAsync(TermstoreTermListRelationsParameter parameter)
        {
            return await this.SendAsync<TermstoreTermListRelationsParameter, TermstoreTermListRelationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreTermListRelationsResponse> TermstoreTermListRelationsAsync(TermstoreTermListRelationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreTermListRelationsParameter, TermstoreTermListRelationsResponse>(parameter, cancellationToken);
        }
    }
}
