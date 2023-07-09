using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/attendeeavailability?view=graph-rest-1.0
    /// </summary>
    public partial class AttendeeAvailability
    {
        public enum AttendeeAvailabilityFreeBusyStatus
        {
            Free,
            Tentative,
            Busy,
            Oof,
            WorkingElsewhere,
            Unknown,
        }

        public AttendeeBase? Attendee { get; set; }
        public AttendeeAvailabilityFreeBusyStatus Availability { get; set; }
    }
}
