using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/timerange?view=graph-rest-1.0
    /// </summary>
    public partial class TimeRange
    {
        public TimeOnly EndTime { get; set; }
        public TimeOnly StartTime { get; set; }
    }
}
