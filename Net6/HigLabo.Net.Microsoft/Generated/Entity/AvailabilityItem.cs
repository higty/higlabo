using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/availabilityitem?view=graph-rest-1.0
    /// </summary>
    public partial class AvailabilityItem
    {
        public enum AvailabilityItemBookingsAvailabilityStatus
        {
            Available,
            Busy,
            SlotsAvailable,
            OutOfOffice,
            UnknownFutureValue,
        }

        public DateTimeTimeZone? EndDateTime { get; set; }
        public string? ServiceId { get; set; }
        public AvailabilityItemBookingsAvailabilityStatus Status { get; set; }
        public DateTimeTimeZone? StartDateTime { get; set; }
    }
}
