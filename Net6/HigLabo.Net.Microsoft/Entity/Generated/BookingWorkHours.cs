using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/bookingworkhours?view=graph-rest-1.0
    /// </summary>
    public partial class BookingWorkHours
    {
        public string Day { get; set; }
        public BookingWorkTimeSlot[] TimeSlots { get; set; }
    }
}
