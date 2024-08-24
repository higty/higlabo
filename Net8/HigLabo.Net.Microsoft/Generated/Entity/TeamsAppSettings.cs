using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teamsappsettings?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsAppSettings
    {
        public bool? AllowUserRequestsForAppAccess { get; set; }
        public string? Id { get; set; }
        public bool? IsUserPersonalScopeResourceSpecificConsentEnabled { get; set; }
    }
}
