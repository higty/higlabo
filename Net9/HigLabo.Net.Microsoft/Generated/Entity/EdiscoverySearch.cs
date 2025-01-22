using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoverysearch?view=graph-rest-1.0
/// </summary>
public partial class EDiscoverySearch
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
