using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-auditing-auditevent?view=graph-rest-1.0
    /// </summary>
    public partial class AuditEvent
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? ComponentName { get; set; }
        public AuditActor? Actor { get; set; }
        public string? Activity { get; set; }
        public DateTimeOffset? ActivityDateTime { get; set; }
        public string? ActivityType { get; set; }
        public string? ActivityOperationType { get; set; }
        public string? ActivityResult { get; set; }
        public Guid? CorrelationId { get; set; }
        public AuditResource[]? Resources { get; set; }
        public string? Category { get; set; }
    }
}
