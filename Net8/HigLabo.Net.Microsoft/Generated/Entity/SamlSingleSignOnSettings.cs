using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/samlsinglesignonsettings?view=graph-rest-1.0
/// </summary>
public partial class SamlSingleSignOnSettings
{
    public string? RelayState { get; set; }
}
