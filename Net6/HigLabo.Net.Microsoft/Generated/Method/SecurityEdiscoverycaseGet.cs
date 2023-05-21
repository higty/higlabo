using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId,
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
    public partial class SecurityEdiscoverycaseGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseGetResponse> SecurityEdiscoverycaseGetAsync()
        {
            var p = new SecurityEdiscoverycaseGetParameter();
            return await this.SendAsync<SecurityEdiscoverycaseGetParameter, SecurityEdiscoverycaseGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseGetResponse> SecurityEdiscoverycaseGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseGetParameter();
            return await this.SendAsync<SecurityEdiscoverycaseGetParameter, SecurityEdiscoverycaseGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseGetResponse> SecurityEdiscoverycaseGetAsync(SecurityEdiscoverycaseGetParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseGetParameter, SecurityEdiscoverycaseGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseGetResponse> SecurityEdiscoverycaseGetAsync(SecurityEdiscoverycaseGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseGetParameter, SecurityEdiscoverycaseGetResponse>(parameter, cancellationToken);
        }
    }
}
