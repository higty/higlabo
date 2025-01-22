using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-get?view=graph-rest-1.0
/// </summary>
public partial class SecurityEDiscoverysearchGetParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId,
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
public partial class SecurityEDiscoverysearchGetResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchGetResponse> SecurityEDiscoverysearchGetAsync()
    {
        var p = new SecurityEDiscoverysearchGetParameter();
        return await this.SendAsync<SecurityEDiscoverysearchGetParameter, SecurityEDiscoverysearchGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchGetResponse> SecurityEDiscoverysearchGetAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityEDiscoverysearchGetParameter();
        return await this.SendAsync<SecurityEDiscoverysearchGetParameter, SecurityEDiscoverysearchGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchGetResponse> SecurityEDiscoverysearchGetAsync(SecurityEDiscoverysearchGetParameter parameter)
    {
        return await this.SendAsync<SecurityEDiscoverysearchGetParameter, SecurityEDiscoverysearchGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityEDiscoverysearchGetResponse> SecurityEDiscoverysearchGetAsync(SecurityEDiscoverysearchGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityEDiscoverysearchGetParameter, SecurityEDiscoverysearchGetResponse>(parameter, cancellationToken);
    }
}
