using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/bookingsavailabilitywindow?view=graph-rest-1.0
/// </summary>
public partial class BookingsAvailabilityWindow
{
    public enum BookingsAvailabilityWindowBookingsServiceAvailabilityType
    {
        BookWhenStaffAreFree,
        NotBookable,
        CustomWeeklyHours,
        UnknownFutureValue,
    }

    public BookingsAvailabilityWindowBookingsServiceAvailabilityType AvailabilityType { get; set; }
    public BookingWorkHours[]? BusinessHours { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? StartDate { get; set; }
}
