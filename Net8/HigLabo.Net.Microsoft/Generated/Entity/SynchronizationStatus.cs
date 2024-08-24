using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationstatus?view=graph-rest-1.0
    /// </summary>
    public partial class SynchronizationStatus
    {
        public enum SynchronizationStatusSynchronizationStatusCode
        {
            NotConfigured,
            NotRun,
            Active,
            Paused,
            Quarantine,
        }

        public SynchronizationStatusSynchronizationStatusCode Code { get; set; }
        public Int64? CountSuccessiveCompleteFailures { get; set; }
        public bool? EscrowsPruned { get; set; }
        public SynchronizationTaskExecution? LastExecution { get; set; }
        public SynchronizationTaskExecution? LastSuccessfulExecution { get; set; }
        public SynchronizationTaskExecution? LastSuccessfulExecutionWithExports { get; set; }
        public SynchronizationProgress[]? Progress { get; set; }
        public SynchronizationQuarantine? Quarantine { get; set; }
        public DateTimeOffset? SteadyStateFirstAchievedTime { get; set; }
        public DateTimeOffset? SteadyStateLastAchievedTime { get; set; }
        public StringKeyLongValuePair[]? SynchronizedEntryCountByType { get; set; }
        public string? TroubleshootingUrl { get; set; }
    }
}
