using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreRelationPostParameter : IRestApiParameter
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
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations: return $"/sites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/relations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum TermStoreRelationPostParameterTermStoreRelationType
        {
            Pin,
            Reuse,
        }
        public enum TermStoreRelationTermStoreRelationType
        {
            Pin,
            Reuse,
        }
        public enum ApiPath
        {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TermStoreRelationPostParameterTermStoreRelationType Relationship { get; set; }
        public TermStoreSet? Set { get; set; }
        public TermStoreTerm? FromTerm { get; set; }
        public string? Id { get; set; }
        public TermStoreTerm? ToTerm { get; set; }
    }
    public partial class TermStoreRelationPostResponse : RestApiResponse
    {
        public enum TermStoreRelationTermStoreRelationType
        {
            Pin,
            Reuse,
        }

        public string? Id { get; set; }
        public TermStoreRelationTermStoreRelationType Relationship { get; set; }
        public TermStoreTerm? FromTerm { get; set; }
        public TermStoreSet? Set { get; set; }
        public TermStoreTerm? ToTerm { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreRelationPostResponse> TermStoreRelationPostAsync()
        {
            var p = new TermStoreRelationPostParameter();
            return await this.SendAsync<TermStoreRelationPostParameter, TermStoreRelationPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreRelationPostResponse> TermStoreRelationPostAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreRelationPostParameter();
            return await this.SendAsync<TermStoreRelationPostParameter, TermStoreRelationPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreRelationPostResponse> TermStoreRelationPostAsync(TermStoreRelationPostParameter parameter)
        {
            return await this.SendAsync<TermStoreRelationPostParameter, TermStoreRelationPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-relation-post?view=graph-rest-1.0
        /// </summary>
        public async Task<TermStoreRelationPostResponse> TermStoreRelationPostAsync(TermStoreRelationPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreRelationPostParameter, TermStoreRelationPostResponse>(parameter, cancellationToken);
        }
    }
}
