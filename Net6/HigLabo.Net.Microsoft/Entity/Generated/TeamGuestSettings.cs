using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamguestsettings?view=graph-rest-1.0
    /// </summary>
    public partial class TeamGuestSettings
    {
        public bool AllowCreateUpdateChannels { get; set; }
        public bool AllowDeleteChannels { get; set; }
    }
}
