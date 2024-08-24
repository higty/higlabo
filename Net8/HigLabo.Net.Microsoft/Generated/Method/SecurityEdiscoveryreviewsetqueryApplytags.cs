using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-applytags?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoveryReviewsetqueryApplytagsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryReviewSetId { get; set; }
            public string? QueryId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_QueryId_ApplyTags: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/queries/{QueryId}/applyTags";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_QueryId_ApplyTags,
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
        public EDiscoveryReviewTag[]? TagsToAdd { get; set; }
        public EDiscoveryReviewTag[]? TagsToRemove { get; set; }
    }
    public partial class SecurityEDiscoveryReviewsetqueryApplytagsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-applytags?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-applytags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetqueryApplytagsResponse> SecurityEDiscoveryReviewsetqueryApplytagsAsync()
        {
            var p = new SecurityEDiscoveryReviewsetqueryApplytagsParameter();
            return await this.SendAsync<SecurityEDiscoveryReviewsetqueryApplytagsParameter, SecurityEDiscoveryReviewsetqueryApplytagsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-applytags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetqueryApplytagsResponse> SecurityEDiscoveryReviewsetqueryApplytagsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoveryReviewsetqueryApplytagsParameter();
            return await this.SendAsync<SecurityEDiscoveryReviewsetqueryApplytagsParameter, SecurityEDiscoveryReviewsetqueryApplytagsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-applytags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetqueryApplytagsResponse> SecurityEDiscoveryReviewsetqueryApplytagsAsync(SecurityEDiscoveryReviewsetqueryApplytagsParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoveryReviewsetqueryApplytagsParameter, SecurityEDiscoveryReviewsetqueryApplytagsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-applytags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetqueryApplytagsResponse> SecurityEDiscoveryReviewsetqueryApplytagsAsync(SecurityEDiscoveryReviewsetqueryApplytagsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoveryReviewsetqueryApplytagsParameter, SecurityEDiscoveryReviewsetqueryApplytagsResponse>(parameter, cancellationToken);
        }
    }
}
