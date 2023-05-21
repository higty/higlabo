using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/attendanceinterval?view=graph-rest-1.0
    /// </summary>
    public partial class AttendanceInterval
    {
        public Int32? DurationInSeconds { get; set; }
        public DateTime? JoinDateTime { get; set; }
        public DateTime? LeaveDateTime { get; set; }
    }
}
