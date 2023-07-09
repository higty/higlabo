using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoverynoncustodialdatasource?view=graph-rest-1.0
    /// </summary>
    public partial class EdiscoveryNoncustodialDataSource
    {
        public enum EdiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EdiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus
        {
            Active,
            Released,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public EdiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EdiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus Status { get; set; }
        public DataSource? DataSource { get; set; }
        public EdiscoveryIndexOperation? LastIndexOperation { get; set; }
    }
}
