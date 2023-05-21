using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-usersource?view=graph-rest-1.0
    /// </summary>
    public partial class UserSource
    {
        public enum UserSourceSecurityDataSourceHoldStatus
        {
            NotApplied,
            Applied,
            Applying,
            Removing,
            Partial,
        }
        public enum UserSourceSecuritySourceType
        {
            Mailbox,
            Site,
        }

        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public UserSourceSecurityDataSourceHoldStatus HoldStatus { get; set; }
        public string? Id { get; set; }
        public UserSourceSecuritySourceType IncludedSources { get; set; }
        public string? SiteWebUrl { get; set; }
    }
}
