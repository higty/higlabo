using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/customextensioncallbackconfiguration?view=graph-rest-1.0
/// </summary>
public partial class CustomExtensionCallbackConfiguration
{
    public string? TimeoutDuration { get; set; }
}
