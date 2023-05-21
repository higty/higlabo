using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/servicehealth?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceHealth
    {
        public enum ServiceHealthServiceHealthStatus
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

        public string? Id { get; set; }
        public string? Service { get; set; }
        public ServiceHealthServiceHealthStatus Status { get; set; }
        public ServiceHealthIssue[]? Issues { get; set; }
    }
}
