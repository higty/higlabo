using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/followupflag?view=graph-rest-1.0
    /// </summary>
    public partial class FollowupFlag
    {
        public enum FollowupFlagFollowupFlagStatus
        {
            NotFlagged,
            Complete,
            Flagged,
        }

        public DateTimeTimeZone? CompletedDateTime { get; set; }
        public DateTimeTimeZone? DueDateTime { get; set; }
        public FollowupFlagFollowupFlagStatus? FlagStatus { get; set; }
        public DateTimeTimeZone? StartDateTime { get; set; }
    }
}
