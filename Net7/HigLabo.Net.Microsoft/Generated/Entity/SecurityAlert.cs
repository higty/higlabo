using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-alert?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityAlert
    {
        public enum SecurityAlertSecurityAlertClassification
        {
            Unknown,
            FalsePositive,
            TruePositive,
            BenignPositive,
            UnknownFutureValue,
        }
        public enum SecurityAlertSecurityAlertDetermination
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
        public enum SecurityAlertSecurityServiceSource
        {
            MicrosoftDefenderForEndpoint,
            MicrosoftDefenderForIdentity,
            MicrosoftCloudAppSecurity,
            MicrosoftDefenderForOffice365,
            Microsoft365Defender,
            AadIdentityProtection,
            AppGovernance,
            DataLossPrevention,
        }
        public enum SecurityAlertSecurityAlertSeverity
        {
            Unknown,
            Informational,
            Low,
            Medium,
            High,
            UnknownFutureValue,
        }
        public enum SecurityAlertSecurityAlertStatus
        {
            New,
            InProgress,
            Resolved,
            UnknownFutureValue,
        }

        public string? ActorDisplayName { get; set; }
        public string? AlertWebUrl { get; set; }
        public string? AssignedTo { get; set; }
        public string? Category { get; set; }
        public SecurityAlertSecurityAlertClassification Classification { get; set; }
        public AlertComment[]? Comments { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public SecurityDetectionSource? DetectionSource { get; set; }
        public string? DetectorId { get; set; }
        public SecurityAlertSecurityAlertDetermination Determination { get; set; }
        public AlertEvidence[]? Evidence { get; set; }
        public DateTimeOffset? FirstActivityDateTime { get; set; }
        public string? Id { get; set; }
        public string? IncidentId { get; set; }
        public string? IncidentWebUrl { get; set; }
        public DateTimeOffset? LastActivityDateTime { get; set; }
        public DateTimeOffset? LastUpdateDateTime { get; set; }
        public string[]? MitreTechniques { get; set; }
        public string? ProviderAlertId { get; set; }
        public string? RecommendedActions { get; set; }
        public DateTimeOffset? ResolvedDateTime { get; set; }
        public SecurityAlertSecurityServiceSource ServiceSource { get; set; }
        public SecurityAlertSecurityAlertSeverity Severity { get; set; }
        public SecurityAlertSecurityAlertStatus Status { get; set; }
        public string? TenantId { get; set; }
        public string? ThreatDisplayName { get; set; }
        public string? ThreatFamilyName { get; set; }
        public string? Title { get; set; }
    }
}
