using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-unifiedgroupsource?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedGroupSource
    {
        public enum UnifiedGroupSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum UnifiedGroupSourceSecuritySourceType
        {
            Mailbox,
            Site,
        }

        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public UnifiedGroupSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public UnifiedGroupSourceSecuritySourceType IncludedSources { get; set; }
        public Group? Group { get; set; }
    }
}
