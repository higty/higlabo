using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/broadcastmeetingsettings?view=graph-rest-1.0
    /// </summary>
    public partial class BroadcastMeetingSettings
    {
        public BroadcastMeetingAudience? AllowedAudience { get; set; }
        public bool? IsRecordingEnabled { get; set; }
        public bool? IsAttendeeReportEnabled { get; set; }
        public bool? IsQuestionAndAnswerEnabled { get; set; }
        public bool? IsVideoOnDemandEnabled { get; set; }
    }
}
