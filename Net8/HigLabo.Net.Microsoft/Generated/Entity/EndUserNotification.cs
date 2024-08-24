using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/endusernotification?view=graph-rest-1.0
    /// </summary>
    public partial class EndUserNotification
    {
        public enum EndUserNotificationEndUserNotificationType
        {
            Unknown,
            PositiveReinforcement,
            NoTraining,
            TrainingAssignment,
            TrainingReminder,
            UnknownFutureValue,
        }
        public enum EndUserNotificationSimulationContentSource
        {
            Unknown,
            Global,
            Tenant,
            UnknownFutureValue,
        }
        public enum EndUserNotificationSimulationContentStatus
        {
            Unknown,
            Draft,
            Ready,
            Archive,
            Delete,
            UnknownFutureValue,
        }

        public EmailIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public EmailIdentity? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EndUserNotificationEndUserNotificationType NotificationType { get; set; }
        public Simulation? Source { get; set; }
        public EndUserNotificationSimulationContentStatus Status { get; set; }
        public String[]? SupportedLocales { get; set; }
    }
}
