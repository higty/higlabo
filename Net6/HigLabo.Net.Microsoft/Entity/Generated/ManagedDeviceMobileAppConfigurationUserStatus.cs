using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-manageddevicemobileappconfigurationuserstatus?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedDeviceMobileAppConfigurationUserStatus
    {
        public enum ManagedDeviceMobileAppConfigurationUserStatusComplianceStatus
        {
            Unknown,
            NotApplicable,
            Compliant,
            Remediated,
            NonCompliant,
            Error,
            Conflict,
            NotAssigned,
        }

        public string? Id { get; set; }
        public string? UserDisplayName { get; set; }
        public Int32? DevicesCount { get; set; }
        public ComplianceStatus? Status { get; set; }
        public DateTimeOffset? LastReportedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
    }
}
