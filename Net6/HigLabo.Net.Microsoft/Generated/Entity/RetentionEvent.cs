using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-retentionevent?view=graph-rest-1.0
    /// </summary>
    public partial class RetentionEvent
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public EventPropagationResult? EventPropagationResult { get; set; }
        public EventQuery[]? EventQueries { get; set; }
        public RetentionEventStatus[]? RetentionEventStatus { get; set; }
        public DateTimeOffset? EventTriggerDateTime { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LastStatusUpdateDateTime { get; set; }
        public RetentionEventType? RetentionEventType { get; set; }
    }
}
