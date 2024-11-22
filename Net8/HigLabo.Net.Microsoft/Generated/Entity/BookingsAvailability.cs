using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/bookingsavailability?view=graph-rest-1.0
/// </summary>
public partial class BookingsAvailability
{
    public enum BookingsAvailabilityBookingsServiceAvailabilityType
    {
        BookWhenStaffAreFree,
        NotBookable,
        CustomWeeklyHours,
        UnknownFutureValue,
    }

    public BookingsAvailabilityBookingsServiceAvailabilityType AvailabilityType { get; set; }
    public BookingWorkHours[]? BusinessHours { get; set; }
}
