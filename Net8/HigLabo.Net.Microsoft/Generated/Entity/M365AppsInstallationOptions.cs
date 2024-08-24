using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/m365appsinstallationoptions?view=graph-rest-1.0
    /// </summary>
    public partial class M365AppsInstallationOptions
    {
        public enum M365AppsInstallationOptionsAppsUpdateChannelType
        {
            Current,
            MonthlyEnterprise,
            SemiAnnual,
        }

        public AppsInstallationOptionsForMac? AppsForMac { get; set; }
        public AppsInstallationOptionsForWindows? AppsForWindows { get; set; }
        public M365AppsInstallationOptionsAppsUpdateChannelType UpdateChannel { get; set; }
    }
}
