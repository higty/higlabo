using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/smsauthenticationmethodtarget?view=graph-rest-1.0
/// </summary>
public partial class SmsAuthenticationMethodTarget
{
    public enum SmsAuthenticationMethodTargetAuthenticationMethodTargetType
    {
        User,
        Group,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public bool? IsRegistrationRequired { get; set; }
    public bool? IsUsableForSignIn { get; set; }
    public SmsAuthenticationMethodTargetAuthenticationMethodTargetType TargetType { get; set; }
}
