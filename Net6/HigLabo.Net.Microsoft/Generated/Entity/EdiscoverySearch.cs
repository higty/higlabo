using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoverysearch?view=graph-rest-1.0
    /// </summary>
    public partial class EdiscoverySearch
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
}
