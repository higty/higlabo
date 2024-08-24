using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoverycustodian?view=graph-rest-1.0
    /// </summary>
    public partial class EDiscoveryCustodian
    {
        public enum EDiscoveryCustodianSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum EDiscoveryCustodianSecurityCustodianStatus
        {
            Active,
            Released,
        }

        public DateTimeOffset? AcknowledgedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public EDiscoveryCustodianSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ReleasedDateTime { get; set; }
        public EDiscoveryCustodianSecurityCustodianStatus Status { get; set; }
        public EDiscoveryIndexOperation? LastIndexOperation { get; set; }
        public SiteSource[]? SiteSources { get; set; }
        public UnifiedGroupSource[]? UnifiedGroupSources { get; set; }
        public UserSource[]? UserSources { get; set; }
    }
}
