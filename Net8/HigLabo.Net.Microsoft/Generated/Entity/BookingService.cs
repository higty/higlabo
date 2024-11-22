using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/bookingservice?view=graph-rest-1.0
/// </summary>
public partial class BookingService
{
    public enum BookingServiceBookingPriceType
    {
        Undefined,
        FixedPrice,
        StartingAt,
        Hourly,
        Free,
        PriceVaries,
        CallUs,
        NotSet,
        UnknownFutureValue,
    }

    public string? AdditionalInformation { get; set; }
    public BookingQuestionAssignment[]? CustomQuestions { get; set; }
    public string? DefaultDuration { get; set; }
    public Location? DefaultLocation { get; set; }
    public Double? DefaultPrice { get; set; }
    public BookingServiceBookingPriceType DefaultPriceType { get; set; }
    public BookingReminder[]? DefaultReminders { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsAnonymousJoinEnabled { get; set; }
    public bool? IsHiddenFromCustomers { get; set; }
    public bool? IsLocationOnline { get; set; }
    public string? LanguageTag { get; set; }
    public Int32? MaximumAttendeesCount { get; set; }
    public string? Notes { get; set; }
    public string? PostBuffer { get; set; }
    public string? PreBuffer { get; set; }
    public BookingSchedulingPolicy? SchedulingPolicy { get; set; }
    public bool? SmsNotificationsEnabled { get; set; }
    public String[]? StaffMemberIds { get; set; }
    public string? WebUrl { get; set; }
}
