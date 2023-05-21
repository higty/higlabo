using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-release?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverynoncustodialdatasourceReleaseParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryNoncustodialDataSourceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoveryNoncustodialDataSourceId_Release: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/{EdiscoveryNoncustodialDataSourceId}/release";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoveryNoncustodialDataSourceId_Release,
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
    public partial class SecurityEdiscoverynoncustodialdatasourceReleaseResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-release?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceReleaseResponse> SecurityEdiscoverynoncustodialdatasourceReleaseAsync()
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceReleaseParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceReleaseParameter, SecurityEdiscoverynoncustodialdatasourceReleaseResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceReleaseResponse> SecurityEdiscoverynoncustodialdatasourceReleaseAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceReleaseParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceReleaseParameter, SecurityEdiscoverynoncustodialdatasourceReleaseResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceReleaseResponse> SecurityEdiscoverynoncustodialdatasourceReleaseAsync(SecurityEdiscoverynoncustodialdatasourceReleaseParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceReleaseParameter, SecurityEdiscoverynoncustodialdatasourceReleaseResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-release?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceReleaseResponse> SecurityEdiscoverynoncustodialdatasourceReleaseAsync(SecurityEdiscoverynoncustodialdatasourceReleaseParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceReleaseParameter, SecurityEdiscoverynoncustodialdatasourceReleaseResponse>(parameter, cancellationToken);
        }
    }
}
