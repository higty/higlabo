using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseListNoncustodialdatasourcesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources,
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
    public partial class SecurityEdiscoverycaseListNoncustodialdatasourcesResponse : RestApiResponse
    {
        public EdiscoveryNoncustodialDataSource[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListNoncustodialdatasourcesResponse> SecurityEdiscoverycaseListNoncustodialdatasourcesAsync()
        {
            var p = new SecurityEdiscoverycaseListNoncustodialdatasourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListNoncustodialdatasourcesParameter, SecurityEdiscoverycaseListNoncustodialdatasourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListNoncustodialdatasourcesResponse> SecurityEdiscoverycaseListNoncustodialdatasourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseListNoncustodialdatasourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListNoncustodialdatasourcesParameter, SecurityEdiscoverycaseListNoncustodialdatasourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListNoncustodialdatasourcesResponse> SecurityEdiscoverycaseListNoncustodialdatasourcesAsync(SecurityEdiscoverycaseListNoncustodialdatasourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListNoncustodialdatasourcesParameter, SecurityEdiscoverycaseListNoncustodialdatasourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListNoncustodialdatasourcesResponse> SecurityEdiscoverycaseListNoncustodialdatasourcesAsync(SecurityEdiscoverycaseListNoncustodialdatasourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListNoncustodialdatasourcesParameter, SecurityEdiscoverycaseListNoncustodialdatasourcesResponse>(parameter, cancellationToken);
        }
    }
}
