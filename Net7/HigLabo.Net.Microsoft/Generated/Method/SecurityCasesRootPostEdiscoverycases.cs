using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityCasesRootPostEdiscoverycasesParameter : IRestApiParameter
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

        public enum EdiscoveryCaseSecurityCaseStatus
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
        public EdiscoveryCaseSecurityCaseStatus Status { get; set; }
        public EdiscoveryCustodian[]? Custodians { get; set; }
        public EdiscoveryNoncustodialDataSource[]? NoncustodialDataSources { get; set; }
        public CaseOperation[]? Operations { get; set; }
        public EdiscoveryReviewSet[]? ReviewSets { get; set; }
        public EdiscoverySearch[]? Searches { get; set; }
        public EdiscoveryCaseSettings? Settings { get; set; }
        public EdiscoveryReviewTag[]? Tags { get; set; }
    }
    public partial class SecurityCasesRootPostEdiscoverycasesResponse : RestApiResponse
    {
        public enum EdiscoveryCaseSecurityCaseStatus
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
        public EdiscoveryCaseSecurityCaseStatus Status { get; set; }
        public EdiscoveryCustodian[]? Custodians { get; set; }
        public EdiscoveryNoncustodialDataSource[]? NoncustodialDataSources { get; set; }
        public CaseOperation[]? Operations { get; set; }
        public EdiscoveryReviewSet[]? ReviewSets { get; set; }
        public EdiscoverySearch[]? Searches { get; set; }
        public EdiscoveryCaseSettings? Settings { get; set; }
        public EdiscoveryReviewTag[]? Tags { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootPostEdiscoverycasesResponse> SecurityCasesRootPostEdiscoverycasesAsync()
        {
            var p = new SecurityCasesRootPostEdiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootPostEdiscoverycasesParameter, SecurityCasesRootPostEdiscoverycasesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootPostEdiscoverycasesResponse> SecurityCasesRootPostEdiscoverycasesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityCasesRootPostEdiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootPostEdiscoverycasesParameter, SecurityCasesRootPostEdiscoverycasesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootPostEdiscoverycasesResponse> SecurityCasesRootPostEdiscoverycasesAsync(SecurityCasesRootPostEdiscoverycasesParameter parameter)
        {
            return await this.SendAsync<SecurityCasesRootPostEdiscoverycasesParameter, SecurityCasesRootPostEdiscoverycasesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-post-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootPostEdiscoverycasesResponse> SecurityCasesRootPostEdiscoverycasesAsync(SecurityCasesRootPostEdiscoverycasesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityCasesRootPostEdiscoverycasesParameter, SecurityCasesRootPostEdiscoverycasesResponse>(parameter, cancellationToken);
        }
    }
}
