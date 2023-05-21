using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bookingworktimeslot?view=graph-rest-1.0
    /// </summary>
    public partial class BookingWorkTimeSlot
    {
        public TimeOnly? EndTime { get; set; }
        public TimeOnly? StartTime { get; set; }
    }
}
