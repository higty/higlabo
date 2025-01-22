using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/bookingbusiness?view=graph-rest-1.0
/// </summary>
public partial class BookingBusiness
{
    public PhysicalAddress? Address { get; set; }
    public BookingWorkHours[]? BusinessHours { get; set; }
    public string? BusinessType { get; set; }
    public string? DefaultCurrencyIso { get; set; }
    public string? DisplayName { get; set; }
    public string? Email { get; set; }
    public string? Id { get; set; }
    public bool? IsPublished { get; set; }
    public string? LanguageTag { get; set; }
    public string? Phone { get; set; }
    public string? PublicUrl { get; set; }
    public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
    public string? WebSiteUrl { get; set; }
    public BookingAppointment[]? Appointments { get; set; }
    public BookingAppointment[]? CalendarView { get; set; }
    public BookingCustomer[]? Customers { get; set; }
    public BookingCustomQuestion[]? CustomQuestions { get; set; }
    public BookingService[]? Services { get; set; }
    public BookingStaffMember[]? StaffMembers { get; set; }
}
