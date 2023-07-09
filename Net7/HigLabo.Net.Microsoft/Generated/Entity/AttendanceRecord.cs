using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/attendancerecord?view=graph-rest-1.0
    /// </summary>
    public partial class AttendanceRecord
    {
        public AttendanceInterval[]? AttendanceIntervals { get; set; }
        public string? EmailAddress { get; set; }
        public Identity? Identity { get; set; }
        public string? Role { get; set; }
        public Int32? TotalAttendanceInSeconds { get; set; }
    }
}
