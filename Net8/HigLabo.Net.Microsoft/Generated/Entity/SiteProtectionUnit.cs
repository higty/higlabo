using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/siteprotectionunit?view=graph-rest-1.0
    /// </summary>
    public partial class SiteProtectionUnit
    {
        public enum SiteProtectionUnitProtectionUnitStatus
        {
            ProtectRequested,
            Protected,
            UnprotectRequested,
            Unprotected,
            RemoveRequested,
            UnknownFutureValue,
        }

        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public PublicError? Error { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? PolicyId { get; set; }
        public string? SiteId { get; set; }
        public string? SiteName { get; set; }
        public string? SiteWebUrl { get; set; }
        public SiteProtectionUnit? Status { get; set; }
    }
}
