using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter : IRestApiParameter
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoveryNoncustodialDataSourceId_UpdateIndex: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/{EdiscoveryNoncustodialDataSourceId}/updateIndex";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoveryNoncustodialDataSourceId_UpdateIndex,
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
    public partial class SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEdiscoverynoncustodialdatasourceUpdateindexAsync()
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEdiscoverynoncustodialdatasourceUpdateindexAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEdiscoverynoncustodialdatasourceUpdateindexAsync(SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEdiscoverynoncustodialdatasourceUpdateindexAsync(SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEdiscoverynoncustodialdatasourceUpdateindexResponse>(parameter, cancellationToken);
        }
    }
}
