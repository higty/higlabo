using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter : IRestApiParameter
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
    public partial class SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse : RestApiResponse
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
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEDiscoverynoncustodialdatasourceRemoveholdAsync()
        {
            var p = new SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter();
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEDiscoverynoncustodialdatasourceRemoveholdAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter();
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEDiscoverynoncustodialdatasourceRemoveholdAsync(SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-removehold?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse> SecurityEDiscoverynoncustodialdatasourceRemoveholdAsync(SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceRemoveholdParameter, SecurityEDiscoverynoncustodialdatasourceRemoveholdResponse>(parameter, cancellationToken);
        }
    }
}
