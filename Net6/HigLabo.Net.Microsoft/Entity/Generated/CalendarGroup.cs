using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/calendargroup?view=graph-rest-1.0
    /// </summary>
    public partial class CalendarGroup
    {
        public string? Name { get; set; }
        public string? ChangeKey { get; set; }
        public Guid? ClassId { get; set; }
        public string? Id { get; set; }
        public Calendar[]? Calendars { get; set; }
    }
}
