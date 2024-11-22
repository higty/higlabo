using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-customtaskextensioncallbackconfiguration?view=graph-rest-1.0
/// </summary>
public partial class CustomTaskExtensionCallbackConfiguration
{
    public string? TimeoutDuration { get; set; }
    public Application[]? AuthorizedApps { get; set; }
}
