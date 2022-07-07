using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreRelationPostParameter : IRestApiParameter
    {
        public enum TermstoreRelationPostParameterTermStoreRelationType
        {
            Pin,
            Reuse,
        }
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations: return $"/ites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/relations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TermstoreRelationPostParameterTermStoreRelationType Relationship { get; set; }
        public TermStoreSet? Set { get; set; }
        public TermStoreTerm? FromTerm { get; set; }
        public string SiteId { get; set; }
        public string SetId { get; set; }
        public string TermId { get; set; }
    }
    public partial class TermstoreRelationPostResponse : RestApiResponse
    {
        public enum RelationTermStoreRelationType
        {
            Pin,
            Reuse,
        }

        public string? Id { get; set; }
        public RelationTermStoreRelationType Relationship { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreRelationPostResponse> TermstoreRelationPostAsync()
        {
            var p = new TermstoreRelationPostParameter();
            return await this.SendAsync<TermstoreRelationPostParameter, TermstoreRelationPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreRelationPostResponse> TermstoreRelationPostAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreRelationPostParameter();
            return await this.SendAsync<TermstoreRelationPostParameter, TermstoreRelationPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreRelationPostResponse> TermstoreRelationPostAsync(TermstoreRelationPostParameter parameter)
        {
            return await this.SendAsync<TermstoreRelationPostParameter, TermstoreRelationPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreRelationPostResponse> TermstoreRelationPostAsync(TermstoreRelationPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreRelationPostParameter, TermstoreRelationPostResponse>(parameter, cancellationToken);
        }
    }
}
