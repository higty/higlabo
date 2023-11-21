using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverynoncustodialdatasourceGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SecurityEdiscoverynoncustodialdatasourceGetResponse : RestApiResponse
    {
        public enum EdiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EdiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus
        {
            Active,
            Released,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public EdiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EdiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus Status { get; set; }
        public DataSource? DataSource { get; set; }
        public EdiscoveryIndexOperation? LastIndexOperation { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverynoncustodialdatasourceGetResponse> SecurityEdiscoverynoncustodialdatasourceGetAsync()
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceGetParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceGetParameter, SecurityEdiscoverynoncustodialdatasourceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverynoncustodialdatasourceGetResponse> SecurityEdiscoverynoncustodialdatasourceGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverynoncustodialdatasourceGetParameter();
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceGetParameter, SecurityEdiscoverynoncustodialdatasourceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverynoncustodialdatasourceGetResponse> SecurityEdiscoverynoncustodialdatasourceGetAsync(SecurityEdiscoverynoncustodialdatasourceGetParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceGetParameter, SecurityEdiscoverynoncustodialdatasourceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverynoncustodialdatasource-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverynoncustodialdatasourceGetResponse> SecurityEdiscoverynoncustodialdatasourceGetAsync(SecurityEdiscoverynoncustodialdatasourceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverynoncustodialdatasourceGetParameter, SecurityEdiscoverynoncustodialdatasourceGetResponse>(parameter, cancellationToken);
        }
    }
}
