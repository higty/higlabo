using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewsetAddtoreviewsetParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EDiscoveryCaseId { get; set; }
            public string? EDiscoveryReviewSetId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EDiscoveryCaseId_ReviewSets_EDiscoveryReviewSetId_AddToReviewSet: return $"/security/cases/ediscoveryCases/{EDiscoveryCaseId}/reviewSets/{EDiscoveryReviewSetId}/addToReviewSet";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EDiscoveryCaseId_ReviewSets_EDiscoveryReviewSetId_AddToReviewSet,
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
        public EdiscoverySearch? Search { get; set; }
        public AdditionalDataOptions? AdditionalDataOptions { get; set; }
    }
    public partial class SecurityEdiscoveryreviewsetAddtoreviewsetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetAddtoreviewsetResponse> SecurityEdiscoveryreviewsetAddtoreviewsetAsync()
        {
            var p = new SecurityEdiscoveryreviewsetAddtoreviewsetParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetAddtoreviewsetParameter, SecurityEdiscoveryreviewsetAddtoreviewsetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetAddtoreviewsetResponse> SecurityEdiscoveryreviewsetAddtoreviewsetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewsetAddtoreviewsetParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetAddtoreviewsetParameter, SecurityEdiscoveryreviewsetAddtoreviewsetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetAddtoreviewsetResponse> SecurityEdiscoveryreviewsetAddtoreviewsetAsync(SecurityEdiscoveryreviewsetAddtoreviewsetParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetAddtoreviewsetParameter, SecurityEdiscoveryreviewsetAddtoreviewsetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetAddtoreviewsetResponse> SecurityEdiscoveryreviewsetAddtoreviewsetAsync(SecurityEdiscoveryreviewsetAddtoreviewsetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetAddtoreviewsetParameter, SecurityEdiscoveryreviewsetAddtoreviewsetResponse>(parameter, cancellationToken);
        }
    }
}
