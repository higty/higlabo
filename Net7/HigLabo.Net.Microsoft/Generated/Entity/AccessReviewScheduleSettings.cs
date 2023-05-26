using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewschedulesettings?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewScheduleSettings
    {
        public AccessReviewApplyAction[]? ApplyActions { get; set; }
        public bool? AutoApplyDecisionsEnabled { get; set; }
        public bool? DecisionHistoriesForReviewersEnabled { get; set; }
        public string? DefaultDecision { get; set; }
        public bool? DefaultDecisionEnabled { get; set; }
        public Int32? InstanceDurationInDays { get; set; }
        public bool? JustificationRequiredOnApproval { get; set; }
        public bool? MailNotificationsEnabled { get; set; }
        public bool? RecommendationsEnabled { get; set; }
        public PatternedRecurrence? Recurrence { get; set; }
        public bool? ReminderNotificationsEnabled { get; set; }
    }
}
