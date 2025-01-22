using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationmethodconfiguration?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationMethodConfiguration
{
    public enum AuthenticationMethodConfigurationAuthenticationMethodState
    {
        Enabled,
        Disabled,
    }

    public ExcludeTarget[]? ExcludeTargets { get; set; }
    public string? Id { get; set; }
    public AuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
}
