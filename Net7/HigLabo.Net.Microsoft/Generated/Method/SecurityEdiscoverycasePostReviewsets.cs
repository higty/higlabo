using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycasePostReviewsetsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets,
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
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public EdiscoveryReviewSetQuery[]? Queries { get; set; }
    }
    public partial class SecurityEdiscoverycasePostReviewsetsResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public EdiscoveryReviewSetQuery[]? Queries { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostReviewsetsResponse> SecurityEdiscoverycasePostReviewsetsAsync()
        {
            var p = new SecurityEdiscoverycasePostReviewsetsParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostReviewsetsParameter, SecurityEdiscoverycasePostReviewsetsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostReviewsetsResponse> SecurityEdiscoverycasePostReviewsetsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycasePostReviewsetsParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostReviewsetsParameter, SecurityEdiscoverycasePostReviewsetsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostReviewsetsResponse> SecurityEdiscoverycasePostReviewsetsAsync(SecurityEdiscoverycasePostReviewsetsParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostReviewsetsParameter, SecurityEdiscoverycasePostReviewsetsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-reviewsets?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostReviewsetsResponse> SecurityEdiscoverycasePostReviewsetsAsync(SecurityEdiscoverycasePostReviewsetsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostReviewsetsParameter, SecurityEdiscoverycasePostReviewsetsResponse>(parameter, cancellationToken);
        }
    }
}
