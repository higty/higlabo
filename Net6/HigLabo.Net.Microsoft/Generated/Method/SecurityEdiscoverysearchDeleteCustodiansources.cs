using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverysearchDeleteCustodiansourcesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverySearchId { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources_Id_ref: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/custodianSources/{Id}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_CustodianSources_Id_ref,
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
    public partial class SecurityEdiscoverysearchDeleteCustodiansourcesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-custodiansources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchDeleteCustodiansourcesResponse> SecurityEdiscoverysearchDeleteCustodiansourcesAsync()
        {
            var p = new SecurityEdiscoverysearchDeleteCustodiansourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchDeleteCustodiansourcesParameter, SecurityEdiscoverysearchDeleteCustodiansourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchDeleteCustodiansourcesResponse> SecurityEdiscoverysearchDeleteCustodiansourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverysearchDeleteCustodiansourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchDeleteCustodiansourcesParameter, SecurityEdiscoverysearchDeleteCustodiansourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchDeleteCustodiansourcesResponse> SecurityEdiscoverysearchDeleteCustodiansourcesAsync(SecurityEdiscoverysearchDeleteCustodiansourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverysearchDeleteCustodiansourcesParameter, SecurityEdiscoverysearchDeleteCustodiansourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-custodiansources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchDeleteCustodiansourcesResponse> SecurityEdiscoverysearchDeleteCustodiansourcesAsync(SecurityEdiscoverysearchDeleteCustodiansourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverysearchDeleteCustodiansourcesParameter, SecurityEdiscoverysearchDeleteCustodiansourcesResponse>(parameter, cancellationToken);
        }
    }
}
