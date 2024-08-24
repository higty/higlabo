using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycasePostCustodiansParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EDiscoveryCustodianSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EDiscoveryCustodianSecurityCustodianStatus
        {
            Active,
            Released,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians,
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
        public string? Email { get; set; }
        public DateTimeOffset? AcknowledgedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public EDiscoveryCustodianSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EDiscoveryCustodianSecurityCustodianStatus Status { get; set; }
        public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
        public SiteSource[]? SiteSources { get; set; }
        public UnifiedGroupSource[]? UnifiedGroupSources { get; set; }
        public UserSource[]? UserSources { get; set; }
    }
    public partial class SecurityEDiscoverycasePostCustodiansResponse : RestApiResponse
    {
        public enum EDiscoveryCustodianSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EDiscoveryCustodianSecurityCustodianStatus
        {
            Active,
            Released,
        }

        public DateTimeOffset? AcknowledgedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public EDiscoveryCustodianSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EDiscoveryCustodianSecurityCustodianStatus Status { get; set; }
        public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
        public SiteSource[]? SiteSources { get; set; }
        public UnifiedGroupSource[]? UnifiedGroupSources { get; set; }
        public UserSource[]? UserSources { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostCustodiansResponse> SecurityEDiscoverycasePostCustodiansAsync()
        {
            var p = new SecurityEDiscoverycasePostCustodiansParameter();
            return await this.SendAsync<SecurityEDiscoverycasePostCustodiansParameter, SecurityEDiscoverycasePostCustodiansResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostCustodiansResponse> SecurityEDiscoverycasePostCustodiansAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycasePostCustodiansParameter();
            return await this.SendAsync<SecurityEDiscoverycasePostCustodiansParameter, SecurityEDiscoverycasePostCustodiansResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostCustodiansResponse> SecurityEDiscoverycasePostCustodiansAsync(SecurityEDiscoverycasePostCustodiansParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycasePostCustodiansParameter, SecurityEDiscoverycasePostCustodiansResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostCustodiansResponse> SecurityEDiscoverycasePostCustodiansAsync(SecurityEDiscoverycasePostCustodiansParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycasePostCustodiansParameter, SecurityEDiscoverycasePostCustodiansResponse>(parameter, cancellationToken);
        }
    }
}
