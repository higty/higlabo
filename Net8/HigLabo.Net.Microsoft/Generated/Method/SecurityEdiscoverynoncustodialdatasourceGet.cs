using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverynoncustodialdatasourceGetParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoveryNoncustodialDataSourceId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialDataSources/{EdiscoveryNoncustodialDataSourceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialDataSources_EdiscoveryNoncustodialDataSourceId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class SecurityEDiscoverynoncustodialdatasourceGetResponse : RestApiResponse
    {
        public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus
        {
            Active,
            Released,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus Status { get; set; }
        public DataSource? DataSource { get; set; }
        public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceGetResponse> SecurityEDiscoverynoncustodialdatasourceGetAsync()
        {
            var p = new SecurityEDiscoverynoncustodialdatasourceGetParameter();
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceGetParameter, SecurityEDiscoverynoncustodialdatasourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceGetResponse> SecurityEDiscoverynoncustodialdatasourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverynoncustodialdatasourceGetParameter();
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceGetParameter, SecurityEDiscoverynoncustodialdatasourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceGetResponse> SecurityEDiscoverynoncustodialdatasourceGetAsync(SecurityEDiscoverynoncustodialdatasourceGetParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceGetParameter, SecurityEDiscoverynoncustodialdatasourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverynoncustodialdatasourceGetResponse> SecurityEDiscoverynoncustodialdatasourceGetAsync(SecurityEDiscoverynoncustodialdatasourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverynoncustodialdatasourceGetParameter, SecurityEDiscoverynoncustodialdatasourceGetResponse>(parameter, cancellationToken);
        }
    }
}
