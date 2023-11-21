using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycasePostNoncustodialdatasourcesParameter : IRestApiParameter
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
        public DataSource? DataSource { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public EdiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EdiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus Status { get; set; }
        public EdiscoveryIndexOperation? LastIndexOperation { get; set; }
    }
    public partial class SecurityEdiscoverycasePostNoncustodialdatasourcesResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostNoncustodialdatasourcesResponse> SecurityEdiscoverycasePostNoncustodialdatasourcesAsync()
        {
            var p = new SecurityEdiscoverycasePostNoncustodialdatasourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostNoncustodialdatasourcesParameter, SecurityEdiscoverycasePostNoncustodialdatasourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostNoncustodialdatasourcesResponse> SecurityEdiscoverycasePostNoncustodialdatasourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycasePostNoncustodialdatasourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostNoncustodialdatasourcesParameter, SecurityEdiscoverycasePostNoncustodialdatasourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostNoncustodialdatasourcesResponse> SecurityEdiscoverycasePostNoncustodialdatasourcesAsync(SecurityEdiscoverycasePostNoncustodialdatasourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostNoncustodialdatasourcesParameter, SecurityEdiscoverycasePostNoncustodialdatasourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-noncustodialdatasources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostNoncustodialdatasourcesResponse> SecurityEdiscoverycasePostNoncustodialdatasourcesAsync(SecurityEdiscoverycasePostNoncustodialdatasourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostNoncustodialdatasourcesParameter, SecurityEdiscoverycasePostNoncustodialdatasourcesResponse>(parameter, cancellationToken);
        }
    }
}
