using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/bookingschedulingpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class BookingSchedulingPolicy
    {
        public bool? AllowStaffSelection { get; set; }
        public string? MaximumAdvance { get; set; }
        public string? MinimumLeadTime { get; set; }
        public bool? SendConfirmationsToOwner { get; set; }
        public string? TimeSlotInterval { get; set; }
    }
}
