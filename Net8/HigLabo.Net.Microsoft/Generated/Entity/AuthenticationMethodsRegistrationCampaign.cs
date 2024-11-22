using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationmethodsregistrationcampaign?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationMethodsRegistrationCampaign
{
    public enum AuthenticationMethodsRegistrationCampaignAdvancedConfigState
    {
        Default,
        Enabled,
        Disabled,
        UnknownFutureValue,
    }

    public ExcludeTarget[]? ExcludeTargets { get; set; }
    public AuthenticationMethodsRegistrationCampaignIncludeTarget[]? IncludeTargets { get; set; }
    public Int32? SnoozeDurationInDays { get; set; }
    public AuthenticationMethodsRegistrationCampaignAdvancedConfigState State { get; set; }
}
