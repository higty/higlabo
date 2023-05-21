using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/usertrainingstatusinfo?view=graph-rest-1.0
    /// </summary>
    public partial class UserTrainingStatusInfo
    {
        public enum UserTrainingStatusInfoTrainingStatus
        {
            Unknown,
            Assigned,
            InProgress,
            Completed,
            Overdue,
            UnknownFutureValue,
        }

        public DateTimeOffset? AssignedDateTime { get; set; }
        public DateTimeOffset? CompletionDateTime { get; set; }
        public string? DisplayName { get; set; }
        public UserTrainingStatusInfoTrainingStatus TrainingStatus { get; set; }
    }
}
