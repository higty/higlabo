using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-searches?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverycasePostSearchesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? EdiscoveryCaseId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum SecurityEDiscoverycasePostSearchesParameterSecurityDataSourceScopes
    {
        None,
        AllTenantMailboxes,
        AllTenantSites,
        AllCaseCustodians,
        AllCaseNoncustodialDataSources,
    }
    public enum EDiscoverySearchSecurityDataSourceScopes
    {
        None,
        AllTenantMailboxes,
        AllTenantSites,
        AllCaseCustodians,
        AllCaseNoncustodialDataSources,
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches,
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
    public string? ContentQuery { get; set; }
    public SecurityEDiscoverycasePostSearchesParameterSecurityDataSourceScopes DataSourceScopes { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DataSource[]? AdditionalSources { get; set; }
    public EDiscoveryAddToReviewSetOperation? AddToReviewSetOperation { get; set; }
    public DataSource[]? CustodianSources { get; set; }
    public EDiscoveryEstimateOperation? LastEstimateStatisticsOperation { get; set; }
    public EDiscoveryNoncustodialDataSource[]? NoncustodialSources { get; set; }
}
public partial class SecurityEDiscoverycasePostSearchesResponse : RestApiResponse
{
    public enum EDiscoverySearchSecurityDataSourceScopes
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
    public EDiscoverySearchSecurityDataSourceScopes DataSourceScopes { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DataSource[]? AdditionalSources { get; set; }
    public EDiscoveryAddToReviewSetOperation? AddToReviewSetOperation { get; set; }
    public DataSource[]? CustodianSources { get; set; }
    public EDiscoveryEstimateOperation? LastEstimateStatisticsOperation { get; set; }
    public EDiscoveryNoncustodialDataSource[]? NoncustodialSources { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-searches?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-searches?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostSearchesResponse> SecurityEDiscoverycasePostSearchesAsync()
    {
        var p = new SecurityEDiscoverycasePostSearchesParameter();
        return await this.SendAsync<SecurityEDiscoverycasePostSearchesParameter, SecurityEDiscoverycasePostSearchesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-searches?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostSearchesResponse> SecurityEDiscoverycasePostSearchesAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverycasePostSearchesParameter();
        return await this.SendAsync<SecurityEDiscoverycasePostSearchesParameter, SecurityEDiscoverycasePostSearchesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-searches?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostSearchesResponse> SecurityEDiscoverycasePostSearchesAsync(SecurityEDiscoverycasePostSearchesParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverycasePostSearchesParameter, SecurityEDiscoverycasePostSearchesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-searches?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverycasePostSearchesResponse> SecurityEDiscoverycasePostSearchesAsync(SecurityEDiscoverycasePostSearchesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverycasePostSearchesParameter, SecurityEDiscoverycasePostSearchesResponse>(parameter, cancellationToken);
    }
}
