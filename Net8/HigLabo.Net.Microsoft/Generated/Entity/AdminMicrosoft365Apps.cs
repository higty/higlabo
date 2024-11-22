using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/adminmicrosoft365apps?view=graph-rest-1.0
/// </summary>
public partial class AdminMicrosoft365Apps
{
    public M365AppsInstallationOptions? InstallationOptions { get; set; }
}
