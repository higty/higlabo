using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoveryReviewsetAddtoReviewsetParameter : IRestApiParameter
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
        public EDiscoverySearch? Search { get; set; }
        public AdditionalDataOptions? AdditionalDataOptions { get; set; }
    }
    public partial class SecurityEDiscoveryReviewsetAddtoReviewsetResponse : RestApiResponse
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
        public async ValueTask<SecurityEDiscoveryReviewsetAddtoReviewsetResponse> SecurityEDiscoveryReviewsetAddtoReviewsetAsync()
        {
            var p = new SecurityEDiscoveryReviewsetAddtoReviewsetParameter();
            return await this.SendAsync<SecurityEDiscoveryReviewsetAddtoReviewsetParameter, SecurityEDiscoveryReviewsetAddtoReviewsetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetAddtoReviewsetResponse> SecurityEDiscoveryReviewsetAddtoReviewsetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoveryReviewsetAddtoReviewsetParameter();
            return await this.SendAsync<SecurityEDiscoveryReviewsetAddtoReviewsetParameter, SecurityEDiscoveryReviewsetAddtoReviewsetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetAddtoReviewsetResponse> SecurityEDiscoveryReviewsetAddtoReviewsetAsync(SecurityEDiscoveryReviewsetAddtoReviewsetParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoveryReviewsetAddtoReviewsetParameter, SecurityEDiscoveryReviewsetAddtoReviewsetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoveryReviewsetAddtoReviewsetResponse> SecurityEDiscoveryReviewsetAddtoReviewsetAsync(SecurityEDiscoveryReviewsetAddtoReviewsetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoveryReviewsetAddtoReviewsetParameter, SecurityEDiscoveryReviewsetAddtoReviewsetResponse>(parameter, cancellationToken);
        }
    }
}
