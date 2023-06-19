using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-delete-queries?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewsetDeleteQueriesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EDiscoveryCaseId { get; set; }
            public string? EdiscoveryReviewSetId { get; set; }
            public string? EDiscoveryReviewSetQueryId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EDiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_EDiscoveryReviewSetQueryId: return $"/security/cases/ediscoveryCases/{EDiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/queries/{EDiscoveryReviewSetQueryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EDiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_EDiscoveryReviewSetQueryId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class SecurityEdiscoveryreviewsetDeleteQueriesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-delete-queries?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-delete-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetDeleteQueriesResponse> SecurityEdiscoveryreviewsetDeleteQueriesAsync()
        {
            var p = new SecurityEdiscoveryreviewsetDeleteQueriesParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetDeleteQueriesParameter, SecurityEdiscoveryreviewsetDeleteQueriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-delete-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetDeleteQueriesResponse> SecurityEdiscoveryreviewsetDeleteQueriesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewsetDeleteQueriesParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetDeleteQueriesParameter, SecurityEdiscoveryreviewsetDeleteQueriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-delete-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetDeleteQueriesResponse> SecurityEdiscoveryreviewsetDeleteQueriesAsync(SecurityEdiscoveryreviewsetDeleteQueriesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetDeleteQueriesParameter, SecurityEdiscoveryreviewsetDeleteQueriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-delete-queries?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetDeleteQueriesResponse> SecurityEdiscoveryreviewsetDeleteQueriesAsync(SecurityEdiscoveryreviewsetDeleteQueriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetDeleteQueriesParameter, SecurityEdiscoveryreviewsetDeleteQueriesResponse>(parameter, cancellationToken);
        }
    }
}
