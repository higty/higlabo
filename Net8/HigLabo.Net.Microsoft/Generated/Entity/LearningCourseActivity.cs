using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/learningcourseactivity?view=graph-rest-1.0
    /// </summary>
    public partial class LearningCourseActivity
    {
        public enum LearningCourseActivityAssignmentType
        {
            Required,
            Recommended,
            UnknownFutureValue,
            PeerRecommended,
        }
        public enum LearningCourseActivityCourseStatus
        {
            NotStarted,
            InProgress,
            Completed,
        }

        public DateTimeOffset? AssignedDateTime { get; set; }
        public string? AssignerUserId { get; set; }
        public LearningCourseActivityAssignmentType AssignmentType { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public Int32? CompletionPercentage { get; set; }
        public DateTimeTimeZone? DueDateTime { get; set; }
        public string? ExternalCourseActivityId { get; set; }
        public string? Id { get; set; }
        public string? LearnerUserId { get; set; }
        public string? LearningContentId { get; set; }
        public string? LearningProviderId { get; set; }
        public DateTimeOffset? StartedDateTime { get; set; }
        public LearningCourseActivityCourseStatus Status { get; set; }
    }
}
