using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcauditevent?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcAuditEvent
    {
        public string? Activity { get; set; }
        public DateTimeOffset? ActivityDateTime { get; set; }
        public CloudPcAuditActivityOperationType? ActivityOperationType { get; set; }
        public CloudPcAuditActivityResult? ActivityResult { get; set; }
        public string? ActivityType { get; set; }
        public CloudPcAuditActor? Actor { get; set; }
        public CloudPcAuditCategory? Category { get; set; }
        public string? ComponentName { get; set; }
        public string? CorrelationId { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public CloudPcAuditResource[]? Resources { get; set; }
    }
}
