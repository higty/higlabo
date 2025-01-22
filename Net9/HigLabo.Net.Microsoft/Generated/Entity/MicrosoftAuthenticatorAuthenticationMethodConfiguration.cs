using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/microsoftauthenticatorauthenticationmethodconfiguration?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftAuthenticatorAuthenticationMethodConfiguration
{
    public enum MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState
    {
        Enabled,
        Disabled,
    }

    public ExcludeTarget[]? ExcludeTargets { get; set; }
    public string? Id { get; set; }
    public MicrosoftAuthenticatorFeatureSettings? FeatureSettings { get; set; }
    public MicrosoftAuthenticatorAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
    public MicrosoftAuthenticatorAuthenticationMethodTarget[]? IncludeTargets { get; set; }
}
