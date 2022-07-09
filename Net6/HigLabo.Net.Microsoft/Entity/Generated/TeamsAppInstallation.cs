using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamsappinstallation?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsAppInstallation
    {
        public string? Id { get; set; }
        public TeamsApp? TeamsApp { get; set; }
        public TeamsAppDefinition? TeamsAppDefinition { get; set; }
    }
}
