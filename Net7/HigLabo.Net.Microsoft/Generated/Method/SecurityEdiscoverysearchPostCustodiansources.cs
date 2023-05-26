using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverysearchPostCustodiansourcesParameter : IRestApiParameter
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
    public partial class SecurityEdiscoverysearchPostCustodiansourcesResponse : RestApiResponse
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
        public async Task<SecurityEdiscoverysearchPostCustodiansourcesResponse> SecurityEdiscoverysearchPostCustodiansourcesAsync()
        {
            var p = new SecurityEdiscoverysearchPostCustodiansourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchPostCustodiansourcesParameter, SecurityEdiscoverysearchPostCustodiansourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchPostCustodiansourcesResponse> SecurityEdiscoverysearchPostCustodiansourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverysearchPostCustodiansourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchPostCustodiansourcesParameter, SecurityEdiscoverysearchPostCustodiansourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchPostCustodiansourcesResponse> SecurityEdiscoverysearchPostCustodiansourcesAsync(SecurityEdiscoverysearchPostCustodiansourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverysearchPostCustodiansourcesParameter, SecurityEdiscoverysearchPostCustodiansourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchPostCustodiansourcesResponse> SecurityEdiscoverysearchPostCustodiansourcesAsync(SecurityEdiscoverysearchPostCustodiansourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverysearchPostCustodiansourcesParameter, SecurityEdiscoverysearchPostCustodiansourcesResponse>(parameter, cancellationToken);
        }
    }
}
