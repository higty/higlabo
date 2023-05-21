using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/automaticrepliessetting?view=graph-rest-1.0
    /// </summary>
    public partial class AutomaticRepliesSetting
    {
        public enum AutomaticRepliesSettingExternalAudienceScope
        {
            AlwaysEnabled,
            Scheduled,
            None,
            ContactsOnly,
            All,
        }
        public enum AutomaticRepliesSettingAutomaticRepliesStatus
        {
            Disabled,
            AlwaysEnabled,
            Scheduled,
        }

        public AutomaticRepliesSettingExternalAudienceScope ExternalAudience { get; set; }
        public string? ExternalReplyMessage { get; set; }
        public string? InternalReplyMessage { get; set; }
        public DateTimeTimeZone? ScheduledEndDateTime { get; set; }
        public DateTimeTimeZone? ScheduledStartDateTime { get; set; }
        public AutomaticRepliesSettingAutomaticRepliesStatus Status { get; set; }
    }
}
