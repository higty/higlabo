using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/alert?view=graph-rest-1.0
    /// </summary>
    public partial class Alert
    {
        public enum AlertAlertFeedback
        {
            Unknown,
            TruePositive,
            FalsePositive,
            BenignPositive,
        }
        public enum AlertAlertSeverity
        {
            Unknown,
            Informational,
            Low,
            Medium,
            High,
        }
        public enum AlertAlertStatus
        {
            Unknown,
            NewAlert,
            InProgress,
            Resolved,
        }

        public string? ActivityGroupName { get; set; }
        public string? AssignedTo { get; set; }
        public string? AzureSubscriptionId { get; set; }
        public string? AzureTenantId { get; set; }
        public string? Category { get; set; }
        public DateTimeOffset? ClosedDateTime { get; set; }
        public CloudAppSecurityState[]? CloudAppStates { get; set; }
        public String[]? Comments { get; set; }
        public Int32? Confidence { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public String[]? DetectionIds { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public AlertAlertFeedback Feedback { get; set; }
        public FileSecurityState[]? FileStates { get; set; }
        public HostSecurityState[]? HostStates { get; set; }
        public string? Id { get; set; }
        public String[]? IncidentIds { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public MalwareState[]? MalwareStates { get; set; }
        public NetworkConnection[]? NetworkConnections { get; set; }
        public Process[]? Processes { get; set; }
        public String[]? RecommendedActions { get; set; }
        public RegistryKeyState[]? RegistryKeyStates { get; set; }
        public SecurityResource[]? SecurityResources { get; set; }
        public AlertAlertSeverity Severity { get; set; }
        public String[]? SourceMaterials { get; set; }
        public AlertAlertStatus Status { get; set; }
        public String[]? Tags { get; set; }
        public string? Title { get; set; }
        public AlertTrigger[]? Triggers { get; set; }
        public UserSecurityState[]? UserStates { get; set; }
        public SecurityVendorInformation? VendorInformation { get; set; }
        public VulnerabilityState[]? VulnerabilityStates { get; set; }
    }
}
