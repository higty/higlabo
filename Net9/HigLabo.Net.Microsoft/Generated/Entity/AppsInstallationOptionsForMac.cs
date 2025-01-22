using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/appsinstallationoptionsformac?view=graph-rest-1.0
/// </summary>
public partial class AppsInstallationOptionsForMac
{
    public bool? IsMicrosoft365AppsEnabled { get; set; }
    public bool? IsSkypeForBusinessEnabled { get; set; }
}
