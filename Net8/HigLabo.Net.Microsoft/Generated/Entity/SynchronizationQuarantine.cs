using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationquarantine?view=graph-rest-1.0
    /// </summary>
    public partial class SynchronizationQuarantine
    {
        public enum SynchronizationQuarantineQuarantineReason
        {
            EncounteredBaseEscrowThreshold,
            EncounteredTotalEscrowThreshold,
            EncounteredEscrowProportionThreshold,
            EncounteredQuarantineException,
            Unknown,
            QuarantinedOnDemand,
            TooManyDeletes,
            IngestionInterrupted,
        }

        public DateTimeOffset? CurrentBegan { get; set; }
        public DateTimeOffset? NextAttempt { get; set; }
        public SynchronizationQuarantineQuarantineReason Reason { get; set; }
        public DateTimeOffset? SeriesBegan { get; set; }
        public Int64? SeriesCount { get; set; }
        public SynchronizationError? Error { get; set; }
    }
}
