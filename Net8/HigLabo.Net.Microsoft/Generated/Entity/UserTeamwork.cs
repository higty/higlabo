using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/userteamwork?view=graph-rest-1.0
    /// </summary>
    public partial class UserTeamwork
    {
        public string? Id { get; set; }
        public string? Locale { get; set; }
        public string? Region { get; set; }
        public AssociatedTeamInfo[]? AssociatedTeams { get; set; }
        public TeamsAppInstallation[]? InstalledApps { get; set; }
    }
}
