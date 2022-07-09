using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accessreviewhistoryschedulesettings?view=graph-rest-1.0
    /// </summary>
    public partial class AccessReviewHistoryScheduleSettings
    {
        public PatternedRecurrence? Recurrence { get; set; }
        public string? ReportRange { get; set; }
    }
}
