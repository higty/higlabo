using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter : IRestApiParameter
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_RemoveHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/removeHold";
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoverynoncustodialDatasourceId_RemoveHold: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/{EdiscoverynoncustodialDatasourceId}/removeHold";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_RemoveHold,
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoverynoncustodialDatasourceId_RemoveHold,
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
    public partial class SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEdiscoverynoncustodialdatasourceRemoveholdAsync()
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEdiscoverynoncustodialdatasourceRemoveholdAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEdiscoverynoncustodialdatasourceRemoveholdAsync(SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEdiscoverynoncustodialdatasourceRemoveholdAsync(SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEdiscoverynoncustodialdatasourceRemoveholdResponse>(parameter, cancellationToken);
        }
    }
}
