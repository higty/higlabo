using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/calendar?view=graph-rest-1.0
    /// </summary>
    public partial class Calendar
    {
        public enum CalendarOnlineMeetingProviderType
        {
            Unknown,
            SkypeForBusiness,
            SkypeForConsumer,
            TeamsForBusiness,
        }
        public enum CalendarCalendarColor
        {
            Auto,
            LightBlue,
            LightGreen,
            LightOrange,
            LightGray,
            LightYellow,
            LightTeal,
            LightPink,
            LightBrown,
            LightRed,
            MaxColor,
        }

        public CalendarOnlineMeetingProviderType AllowedOnlineMeetingProviders { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanShare { get; set; }
        public bool? CanViewPrivateItems { get; set; }
        public string? ChangeKey { get; set; }
        public CalendarCalendarColor Color { get; set; }
        public CalendarOnlineMeetingProviderType DefaultOnlineMeetingProvider { get; set; }
        public string? HexColor { get; set; }
        public string? Id { get; set; }
        public bool? IsDefaultCalendar { get; set; }
        public bool? IsRemovable { get; set; }
        public bool? IsTallyingResponses { get; set; }
        public string? Name { get; set; }
        public EmailAddress? Owner { get; set; }
        public CalendarPermission[]? CalendarPermissions { get; set; }
        public Event[]? CalendarView { get; set; }
        public Event[]? Events { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
}
