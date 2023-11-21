using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-post-queries?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewsetPostQueriesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryReviewSetId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/queries";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries,
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
        public string? DisplayName { get; set; }
        public string? ContentQuery { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Query { get; set; }
    }
    public partial class SecurityEdiscoveryreviewsetPostQueriesResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Query { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-post-queries?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-post-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetPostQueriesResponse> SecurityEdiscoveryreviewsetPostQueriesAsync()
        {
            var p = new SecurityEdiscoveryreviewsetPostQueriesParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetPostQueriesParameter, SecurityEdiscoveryreviewsetPostQueriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-post-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetPostQueriesResponse> SecurityEdiscoveryreviewsetPostQueriesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewsetPostQueriesParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetPostQueriesParameter, SecurityEdiscoveryreviewsetPostQueriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-post-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetPostQueriesResponse> SecurityEdiscoveryreviewsetPostQueriesAsync(SecurityEdiscoveryreviewsetPostQueriesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetPostQueriesParameter, SecurityEdiscoveryreviewsetPostQueriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-post-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetPostQueriesResponse> SecurityEdiscoveryreviewsetPostQueriesAsync(SecurityEdiscoveryreviewsetPostQueriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetPostQueriesParameter, SecurityEdiscoveryreviewsetPostQueriesResponse>(parameter, cancellationToken);
        }
    }
}
