using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/bookingstaffmember?view=graph-rest-1.0
/// </summary>
public partial class BookingStaffMember
{
    public enum BookingStaffMemberBookingStaffRole
    {
        Guest,
        Administrator,
        Viewer,
        ExternalGuest,
        UnknownFutureValue,
        Scheduler,
        TeamMember,
    }

    public bool? AvailabilityIsAffectedByPersonalCalendar { get; set; }
    public string? DisplayName { get; set; }
    public string? EmailAddress { get; set; }
    public string? Id { get; set; }
    public bool? IsEmailNotificationEnabled { get; set; }
    public BookingStaffMemberBookingStaffRole Role { get; set; }
    public string? TimeZone { get; set; }
    public bool? UseBusinessHours { get; set; }
    public BookingWorkHours[]? WorkingHours { get; set; }
}
