using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/usertrainingeventinfo?view=graph-rest-1.0
    /// </summary>
    public partial class UserTrainingEventInfo
    {
        public enum UserTrainingEventInfoTrainingStatus
        {
            Unknown,
            Assigned,
            InProgress,
            Completed,
            Overdue,
            UnknownFutureValue,
        }

        public string? DisplayName { get; set; }
        public UserTrainingEventInfoTrainingStatus LatestTrainingStatus { get; set; }
        public UserTrainingContentEventInfo? TrainingAssignedProperties { get; set; }
        public UserTrainingContentEventInfo? TrainingCompletedProperties { get; set; }
        public UserTrainingContentEventInfo? TrainingUpdatedProperties { get; set; }
    }
}
