using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/timeoffrequest?view=graph-rest-1.0
    /// </summary>
    public partial class TimeOffRequest
    {
        public DateTimeOffset EndDateTime { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public string TimeOffReasonId { get; set; }
    }
}
