using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityCasesRootPostEDiscoverycasesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases: return $"/security/cases/ediscoveryCases";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EDiscoveryCaseSecurityCaseStatus
        {
            Unknown,
            Active,
            PendingDelete,
            Closing,
            Closed,
            ClosedWithError,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases,
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
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? ExternalId { get; set; }
        public IdentitySet? ClosedBy { get; set; }
        public DateTimeOffset? ClosedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EDiscoveryCaseSecurityCaseStatus Status { get; set; }
        public EDiscoveryCustodian[]? Custodians { get; set; }
        public EDiscoveryNoncustodialDataSource[]? NoncustodialDataSources { get; set; }
        public CaseOperation[]? Operations { get; set; }
        public EDiscoveryReviewSet[]? ReviewSets { get; set; }
        public EDiscoverySearch[]? Searches { get; set; }
        public EDiscoveryCaseSettings? Settings { get; set; }
        public EDiscoveryReviewTag[]? Tags { get; set; }
    }
    public partial class SecurityCasesRootPostEDiscoverycasesResponse : RestApiResponse
    {
        public enum EDiscoveryCaseSecurityCaseStatus
        {
            Unknown,
            Active,
            PendingDelete,
            Closing,
            Closed,
            ClosedWithError,
        }

        public IdentitySet? ClosedBy { get; set; }
        public DateTimeOffset? ClosedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EDiscoveryCaseSecurityCaseStatus Status { get; set; }
        public EDiscoveryCustodian[]? Custodians { get; set; }
        public EDiscoveryNoncustodialDataSource[]? NoncustodialDataSources { get; set; }
        public CaseOperation[]? Operations { get; set; }
        public EDiscoveryReviewSet[]? ReviewSets { get; set; }
        public EDiscoverySearch[]? Searches { get; set; }
        public EDiscoveryCaseSettings? Settings { get; set; }
        public EDiscoveryReviewTag[]? Tags { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootPostEDiscoverycasesResponse> SecurityCasesRootPostEDiscoverycasesAsync()
        {
            var p = new SecurityCasesRootPostEDiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootPostEDiscoverycasesParameter, SecurityCasesRootPostEDiscoverycasesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootPostEDiscoverycasesResponse> SecurityCasesRootPostEDiscoverycasesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityCasesRootPostEDiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootPostEDiscoverycasesParameter, SecurityCasesRootPostEDiscoverycasesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootPostEDiscoverycasesResponse> SecurityCasesRootPostEDiscoverycasesAsync(SecurityCasesRootPostEDiscoverycasesParameter parameter)
        {
            return await this.SendAsync<SecurityCasesRootPostEDiscoverycasesParameter, SecurityCasesRootPostEDiscoverycasesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityCasesRootPostEDiscoverycasesResponse> SecurityCasesRootPostEDiscoverycasesAsync(SecurityCasesRootPostEDiscoverycasesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityCasesRootPostEDiscoverycasesParameter, SecurityCasesRootPostEDiscoverycasesResponse>(parameter, cancellationToken);
        }
    }
}
