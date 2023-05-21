using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/organizermeetinginfo?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizerMeetingInfo
    {
        public IdentitySet? Organizer { get; set; }
    }
}
