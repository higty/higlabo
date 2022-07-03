using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/lobbybypasssettings?view=graph-rest-1.0
    /// </summary>
    public partial class LobbyBypassSettings
    {
        public LobbyBypassScope? Scope { get; set; }
        public bool IsDialInBypassEnabled { get; set; }
    }
}
