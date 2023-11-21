using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teamworkonlinemeetinginfo?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworkOnlineMeetingInfo
    {
        public string? CalendarEventId { get; set; }
        public string? JoinWebUrl { get; set; }
        public TeamworkUserIdentity? Organizer { get; set; }
    }
}
