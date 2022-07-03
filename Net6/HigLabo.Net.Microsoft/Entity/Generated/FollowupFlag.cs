using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/followupflag?view=graph-rest-1.0
    /// </summary>
    public partial class FollowupFlag
    {
        public DateTimeTimeZone? CompletedDateTime { get; set; }
        public DateTimeTimeZone? DueDateTime { get; set; }
        public FollowupFlagFollowupFlagStatus FlagStatus { get; set; }
        public DateTimeTimeZone? StartDateTime { get; set; }
    }
}
