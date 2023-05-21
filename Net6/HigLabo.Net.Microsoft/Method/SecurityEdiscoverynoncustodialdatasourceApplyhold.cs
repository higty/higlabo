using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverynoncustodialdatasourceApplyholdParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverynoncustodialDatasourceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_ApplyHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/applyHold";
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoverynoncustodialDatasourceId_ApplyHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/{EdiscoverynoncustodialDatasourceId}/applyHold";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_ApplyHold,
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoverynoncustodialDatasourceId_ApplyHold,
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
        public String[]? Ids { get; set; }
    }
    public partial class SecurityEdiscoverynoncustodialdatasourceApplyholdResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceApplyholdResponse> SecurityEdiscoverynoncustodialdatasourceApplyholdAsync()
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceApplyholdParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceApplyholdParameter, SecurityEdiscoverynoncustodialdatasourceApplyholdResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceApplyholdResponse> SecurityEdiscoverynoncustodialdatasourceApplyholdAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceApplyholdParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceApplyholdParameter, SecurityEdiscoverynoncustodialdatasourceApplyholdResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceApplyholdResponse> SecurityEdiscoverynoncustodialdatasourceApplyholdAsync(SecurityEdiscoverynoncustodialdatasourceApplyholdParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceApplyholdParameter, SecurityEdiscoverynoncustodialdatasourceApplyholdResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-applyhold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceApplyholdResponse> SecurityEdiscoverynoncustodialdatasourceApplyholdAsync(SecurityEdiscoverynoncustodialdatasourceApplyholdParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceApplyholdParameter, SecurityEdiscoverynoncustodialdatasourceApplyholdResponse>(parameter, cancellationToken);
        }
    }
}
