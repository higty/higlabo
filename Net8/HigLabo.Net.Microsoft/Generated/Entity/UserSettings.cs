using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/usersettings?view=graph-rest-1.0
    /// </summary>
    public partial class UserSettings
    {
        public bool? ContributionToContentDiscoveryAsOrganizationDisabled { get; set; }
        public bool? ContributionToContentDiscoveryDisabled { get; set; }
        public string? Id { get; set; }
    }
}
