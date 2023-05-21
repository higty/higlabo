using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/onlinemeetinginfo?view=graph-rest-1.0
    /// </summary>
    public partial class OnlineMeetingInfo
    {
        public string? ConferenceId { get; set; }
        public string? JoinUrl { get; set; }
        public Phone[]? Phones { get; set; }
        public string? QuickDial { get; set; }
        public String[]? TollFreeNumbers { get; set; }
        public string? TollNumber { get; set; }
    }
}
