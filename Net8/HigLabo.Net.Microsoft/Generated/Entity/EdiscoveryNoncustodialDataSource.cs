using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoverynoncustodialdatasource?view=graph-rest-1.0
    /// </summary>
    public partial class EDiscoveryNoncustodialDataSource
    {
        public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus
        {
            Active,
            Released,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public EDiscoveryNoncustodialDataSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EDiscoveryNoncustodialDataSourceSecurityDataSourceContainerStatus Status { get; set; }
        public DataSource? DataSource { get; set; }
        public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
    }
}
