using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/microsoftauthenticatorfeaturesettings?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftAuthenticatorFeatureSettings
{
    public AuthenticationMethodFeatureConfiguration? DisplayAppInformationRequiredState { get; set; }
    public AuthenticationMethodFeatureConfiguration? DisplayLocationInformationRequiredState { get; set; }
}
