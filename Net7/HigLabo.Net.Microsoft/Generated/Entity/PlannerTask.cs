using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/plannertask?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerTask
    {
        public Int32? ActiveChecklistItemCount { get; set; }
        public PlannerAppliedCategories? AppliedCategories { get; set; }
        public string? AssigneePriority { get; set; }
        public PlannerAssignments? Assignments { get; set; }
        public string? BucketId { get; set; }
        public Int32? ChecklistItemCount { get; set; }
        public IdentitySet? CompletedBy { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public string? ConversationThreadId { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? DueDateTime { get; set; }
        public bool? HasDescription { get; set; }
        public string? Id { get; set; }
        public string? OrderHint { get; set; }
        public Int32? PercentComplete { get; set; }
        public string? PlanId { get; set; }
        public string? PreviewType { get; set; }
        public Int32? Priority { get; set; }
        public Int32? ReferenceCount { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Title { get; set; }
        public PlannerAssignedToTaskBoardTaskFormat? AssignedToTaskBoardFormat { get; set; }
        public PlannerBucketTaskBoardTaskFormat? BucketTaskBoardFormat { get; set; }
        public PlannerTaskDetails? Details { get; set; }
        public PlannerProgressTaskBoardTaskFormat? ProgressTaskBoardFormat { get; set; }
    }
}
