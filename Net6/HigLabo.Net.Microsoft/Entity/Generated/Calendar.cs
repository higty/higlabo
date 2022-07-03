using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/calendar?view=graph-rest-1.0
    /// </summary>
    public partial class Calendar
    {
        public CalendarOnlineMeetingProviderType AllowedOnlineMeetingProviders { get; set; }
        public bool CanEdit { get; set; }
        public bool CanShare { get; set; }
        public bool CanViewPrivateItems { get; set; }
        public string ChangeKey { get; set; }
        public CalendarCalendarColor Color { get; set; }
        public CalendarOnlineMeetingProviderType DefaultOnlineMeetingProvider { get; set; }
        public string HexColor { get; set; }
        public string Id { get; set; }
        public bool IsDefaultCalendar { get; set; }
        public bool IsRemovable { get; set; }
        public bool IsTallyingResponses { get; set; }
        public string Name { get; set; }
        public EmailAddress? Owner { get; set; }
    }
}
