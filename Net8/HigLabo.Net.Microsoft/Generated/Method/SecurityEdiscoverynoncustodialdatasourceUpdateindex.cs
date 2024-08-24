using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter : IRestApiParameter
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
    public partial class SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse : RestApiResponse
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
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEDiscoverynoncustodialdatasourceUpdateindexAsync()
        {
            var p = new SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter();
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEDiscoverynoncustodialdatasourceUpdateindexAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter();
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEDiscoverynoncustodialdatasourceUpdateindexAsync(SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-updateindex?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse> SecurityEDiscoverynoncustodialdatasourceUpdateindexAsync(SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceUpdateindexParameter, SecurityEDiscoverynoncustodialdatasourceUpdateindexResponse>(parameter, cancellationToken);
        }
    }
}
