using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverysearchPostCustodiansourcesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverySearchId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources_ref: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/custodianSources/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources_ref,
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
    }
    public partial class SecurityEDiscoverysearchPostCustodiansourcesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchPostCustodiansourcesResponse> SecurityEDiscoverysearchPostCustodiansourcesAsync()
        {
            var p = new SecurityEDiscoverysearchPostCustodiansourcesParameter();
            return await this.SendAsync<SecurityEDiscoverysearchPostCustodiansourcesParameter, SecurityEDiscoverysearchPostCustodiansourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchPostCustodiansourcesResponse> SecurityEDiscoverysearchPostCustodiansourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverysearchPostCustodiansourcesParameter();
            return await this.SendAsync<SecurityEDiscoverysearchPostCustodiansourcesParameter, SecurityEDiscoverysearchPostCustodiansourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchPostCustodiansourcesResponse> SecurityEDiscoverysearchPostCustodiansourcesAsync(SecurityEDiscoverysearchPostCustodiansourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverysearchPostCustodiansourcesParameter, SecurityEDiscoverysearchPostCustodiansourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverysearchPostCustodiansourcesResponse> SecurityEDiscoverysearchPostCustodiansourcesAsync(SecurityEDiscoverysearchPostCustodiansourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverysearchPostCustodiansourcesParameter, SecurityEDiscoverysearchPostCustodiansourcesResponse>(parameter, cancellationToken);
        }
    }
}
