using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/workinghours?view=graph-rest-1.0
    /// </summary>
    public partial class WorkingHours
    {
        public DayOfWeek[]? DaysOfWeek { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public TimeZoneBase? TimeZone { get; set; }
    }
}
