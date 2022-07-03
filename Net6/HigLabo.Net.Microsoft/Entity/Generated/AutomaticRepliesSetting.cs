using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/automaticrepliessetting?view=graph-rest-1.0
    /// </summary>
    public partial class AutomaticRepliesSetting
    {
        public AutomaticRepliesSettingExternalAudienceScope ExternalAudience { get; set; }
        public String? ExternalReplyMessage { get; set; }
        public String? InternalReplyMessage { get; set; }
        public DateTimeTimeZone? ScheduledEndDateTime { get; set; }
        public DateTimeTimeZone? ScheduledStartDateTime { get; set; }
        public AutomaticRepliesSettingAutomaticRepliesStatus Status { get; set; }
    }
}
