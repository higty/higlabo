using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/servicehealthissue?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceHealthIssue
    {
        public enum ServiceHealthIssueServiceHealthClassificationType
        {
            Advisory,
            Incident,
            UnknownFutureValue,
        }
        public enum ServiceHealthIssueServiceHealthOrigin
        {
            Microsoft,
            ThirdParty,
            Customer,
            UnknownFutureValue,
        }
        public enum ServiceHealthIssueServiceHealthStatus
        {
            ServiceOperational,
            Investigating,
            RestoringService,
            VerifyingService,
            ServiceRestored,
            PostIncidentReviewPublished,
            ServiceDegradation,
            ServiceInterruption,
            ExtendedRecovery,
            FalsePositive,
            InvestigationSuspended,
            Resolved,
            MitigatedExternal,
            Mitigated,
            ResolvedExternal,
            Confirmed,
            Reported,
            UnknownFutureValue,
        }

        public ServiceHealthIssueServiceHealthClassificationType Classification { get; set; }
        public KeyValuePair[]? Details { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Feature { get; set; }
        public string? FeatureGroup { get; set; }
        public string? Id { get; set; }
        public string? ImpactDescription { get; set; }
        public bool? IsResolved { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public ServiceHealthIssueServiceHealthOrigin Origin { get; set; }
        public ServiceHealthIssuePost[]? Posts { get; set; }
        public string? Service { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public ServiceHealthIssueServiceHealthStatus Status { get; set; }
        public string? Title { get; set; }
    }
}
