using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/learningselfinitiatedcourse?view=graph-rest-1.0
    /// </summary>
    public partial class LearningSelfInitiatedCourse
    {
        public enum LearningSelfInitiatedCourseCourseStatus
        {
            InProgress,
            Completed,
        }

        public DateTimeOffset? CompletedDateTime { get; set; }
        public Int32? CompletionPercentage { get; set; }
        public string? ExternalCourseActivityId { get; set; }
        public string? Id { get; set; }
        public string? LearningContentId { get; set; }
        public string? LearnerUserId { get; set; }
        public string? LearningProviderId { get; set; }
        public DateTimeOffset? StartedDateTime { get; set; }
        public LearningSelfInitiatedCourseCourseStatus Status { get; set; }
    }
}
