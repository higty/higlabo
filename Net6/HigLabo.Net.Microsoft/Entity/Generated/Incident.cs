using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-incident?view=graph-rest-1.0
    /// </summary>
    public partial class Incident
    {
        public enum IncidentSecurityAlertClassification
        {
            Unknown,
            FalsePositive,
            TruePositive,
            InformationalExpectedActivity,
            UnknownFutureValue,
        }
        public enum IncidentSecurityAlertDetermination
        {
            Unknown,
            Apt,
            Malware,
            SecurityPersonnel,
            SecurityTesting,
            UnwantedSoftware,
            Other,
            MultiStagedAttack,
            CompromisedUser,
            Phishing,
            MaliciousUserActivity,
            Clean,
            InsufficientData,
            ConfirmedUserActivity,
            LineOfBusinessApplication,
            UnknownFutureValue,
        }
        public enum IncidentAlertSeverity
        {
            Unknown,
            Informational,
            Low,
            Medium,
            High,
            UnknownFutureValue,
        }
        public enum IncidentSecurityIncidentStatus
        {
            Active,
            Resolved,
            InProgress,
            Redirected,
            UnknownFutureValue,
        }

        public string? AssignedTo { get; set; }
        public IncidentSecurityAlertClassification Classification { get; set; }
        public AlertComment[]? Comments { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public String[]? CustomTags { get; set; }
        public IncidentSecurityAlertDetermination Determination { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? IncidentWebUrl { get; set; }
        public DateTimeOffset? LastUpdateDateTime { get; set; }
        public string? RedirectIncidentId { get; set; }
        public IncidentAlertSeverity Severity { get; set; }
        public IncidentSecurityIncidentStatus Status { get; set; }
        public string? TenantId { get; set; }
        public SecurityAlert[]? Alerts { get; set; }
    }
}
