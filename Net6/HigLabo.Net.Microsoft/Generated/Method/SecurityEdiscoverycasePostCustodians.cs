using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycasePostCustodiansParameter : IRestApiParameter
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

        public enum EdiscoveryCustodianSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EdiscoveryCustodianSecurityCustodianStatus
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
        public EdiscoveryCustodianSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EdiscoveryCustodianSecurityCustodianStatus Status { get; set; }
        public EdiscoveryIndexOperation? LastIndexOperation { get; set; }
        public SiteSource[]? SiteSources { get; set; }
        public UnifiedGroupSource[]? UnifiedGroupSources { get; set; }
        public UserSource[]? UserSources { get; set; }
    }
    public partial class SecurityEdiscoverycasePostCustodiansResponse : RestApiResponse
    {
        public enum EdiscoveryCustodianSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EdiscoveryCustodianSecurityCustodianStatus
        {
            Active,
            Released,
        }

        public DateTimeOffset? AcknowledgedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public EdiscoveryCustodianSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EdiscoveryCustodianSecurityCustodianStatus Status { get; set; }
        public EdiscoveryIndexOperation? LastIndexOperation { get; set; }
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
        public async Task<SecurityEdiscoverycasePostCustodiansResponse> SecurityEdiscoverycasePostCustodiansAsync()
        {
            var p = new SecurityEdiscoverycasePostCustodiansParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostCustodiansParameter, SecurityEdiscoverycasePostCustodiansResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycasePostCustodiansResponse> SecurityEdiscoverycasePostCustodiansAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycasePostCustodiansParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostCustodiansParameter, SecurityEdiscoverycasePostCustodiansResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycasePostCustodiansResponse> SecurityEdiscoverycasePostCustodiansAsync(SecurityEdiscoverycasePostCustodiansParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostCustodiansParameter, SecurityEdiscoverycasePostCustodiansResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-custodians?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycasePostCustodiansResponse> SecurityEdiscoverycasePostCustodiansAsync(SecurityEdiscoverycasePostCustodiansParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostCustodiansParameter, SecurityEdiscoverycasePostCustodiansResponse>(parameter, cancellationToken);
        }
    }
}
