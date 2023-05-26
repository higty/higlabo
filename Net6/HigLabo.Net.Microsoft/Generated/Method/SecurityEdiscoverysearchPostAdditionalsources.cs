using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-additionalsources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverysearchPostAdditionalsourcesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverySearchId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_AdditionalSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/additionalSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EdiscoverySearchSecurityDataSourceScopes
        {
            None,
            AllTenantMailboxes,
            AllTenantSites,
            AllCaseCustodians,
            AllCaseNoncustodialDataSources,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_AdditionalSources,
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
        public string? Site { get; set; }
        public string? ContentQuery { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public EdiscoverySearchSecurityDataSourceScopes DataSourceScopes { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DataSource[]? AdditionalSources { get; set; }
        public EdiscoveryAddToReviewSetOperation? AddToReviewSetOperation { get; set; }
        public DataSource[]? CustodianSources { get; set; }
        public EdiscoveryEstimateOperation? LastEstimateStatisticsOperation { get; set; }
        public EdiscoveryNoncustodialDataSource[]? NoncustodialSources { get; set; }
    }
    public partial class SecurityEdiscoverysearchPostAdditionalsourcesResponse : RestApiResponse
    {
        public enum EdiscoverySearchSecurityDataSourceScopes
        {
            None,
            AllTenantMailboxes,
            AllTenantSites,
            AllCaseCustodians,
            AllCaseNoncustodialDataSources,
        }

        public string? ContentQuery { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public EdiscoverySearchSecurityDataSourceScopes DataSourceScopes { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DataSource[]? AdditionalSources { get; set; }
        public EdiscoveryAddToReviewSetOperation? AddToReviewSetOperation { get; set; }
        public DataSource[]? CustodianSources { get; set; }
        public EdiscoveryEstimateOperation? LastEstimateStatisticsOperation { get; set; }
        public EdiscoveryNoncustodialDataSource[]? NoncustodialSources { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-additionalsources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-additionalsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchPostAdditionalsourcesResponse> SecurityEdiscoverysearchPostAdditionalsourcesAsync()
        {
            var p = new SecurityEdiscoverysearchPostAdditionalsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchPostAdditionalsourcesParameter, SecurityEdiscoverysearchPostAdditionalsourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-additionalsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchPostAdditionalsourcesResponse> SecurityEdiscoverysearchPostAdditionalsourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverysearchPostAdditionalsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchPostAdditionalsourcesParameter, SecurityEdiscoverysearchPostAdditionalsourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-additionalsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchPostAdditionalsourcesResponse> SecurityEdiscoverysearchPostAdditionalsourcesAsync(SecurityEdiscoverysearchPostAdditionalsourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverysearchPostAdditionalsourcesParameter, SecurityEdiscoverysearchPostAdditionalsourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-post-additionalsources?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverysearchPostAdditionalsourcesResponse> SecurityEdiscoverysearchPostAdditionalsourcesAsync(SecurityEdiscoverysearchPostAdditionalsourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverysearchPostAdditionalsourcesParameter, SecurityEdiscoverysearchPostAdditionalsourcesResponse>(parameter, cancellationToken);
        }
    }
}
