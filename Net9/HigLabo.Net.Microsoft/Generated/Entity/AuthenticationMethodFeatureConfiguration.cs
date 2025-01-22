using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationmethodfeatureconfiguration?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationMethodFeatureConfiguration
{
    public enum AuthenticationMethodFeatureConfigurationAdvancedConfigState
    {
        Default,
        Enabled,
        Disabled,
        UnknownFutureValue,
    }

    public FeatureTarget? ExcludeTarget { get; set; }
    public FeatureTarget? IncludeTarget { get; set; }
    public AuthenticationMethodFeatureConfigurationAdvancedConfigState State { get; set; }
}
