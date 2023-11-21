using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/joinmeetingidsettings?view=graph-rest-1.0
    /// </summary>
    public partial class JoinMeetingIdSettings
    {
        public bool? IsPasscodeRequired { get; set; }
        public string? JoinMeetingId { get; set; }
        public string? Passcode { get; set; }
    }
}
