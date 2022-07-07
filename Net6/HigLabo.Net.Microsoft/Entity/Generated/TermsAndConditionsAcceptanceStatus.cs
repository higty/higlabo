using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-companyterms-termsandconditionsacceptancestatus?view=graph-rest-1.0
    /// </summary>
    public partial class TermsAndConditionsAcceptanceStatus
    {
        public string? Id { get; set; }
        public string? UserDisplayName { get; set; }
        public Int32? AcceptedVersion { get; set; }
        public DateTimeOffset? AcceptedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
    }
}
