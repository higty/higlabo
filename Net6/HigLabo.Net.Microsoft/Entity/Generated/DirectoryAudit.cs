using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/directoryaudit?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryAudit
    {
        public DateTimeOffset ActivityDateTime { get; set; }
        public string ActivityDisplayName { get; set; }
        public KeyValue[] AdditionalDetails { get; set; }
        public string Category { get; set; }
        public Guid? CorrelationId { get; set; }
        public string Id { get; set; }
        public AuditActivityInitiator? InitiatedBy { get; set; }
        public string OperationType { get; set; }
        public string LoggedByService { get; set; }
        public DirectoryAuditOperationResult Result { get; set; }
        public string ResultReason { get; set; }
        public TargetResource[] TargetResources { get; set; }
    }
}
