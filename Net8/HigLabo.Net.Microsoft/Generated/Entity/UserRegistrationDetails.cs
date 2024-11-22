using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/userregistrationdetails?view=graph-rest-1.0
/// </summary>
public partial class UserRegistrationDetails
{
    public enum UserRegistrationDetailsUserDefaultAuthenticationMethod
    {
        Push,
        Oath,
        VoiceMobile,
        VoiceAlternateMobile,
        VoiceOffice,
        Sms,
        None,
        UnknownFutureValue,
        False,
        Any,
        Eq,
    }
    public enum UserRegistrationDetailsSignInUserType
    {
        Member,
        Guest,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public bool? IsAdmin { get; set; }
    public bool? IsMfaCapable { get; set; }
    public bool? IsMfaRegistered { get; set; }
    public bool? IsPasswordlessCapable { get; set; }
    public bool? IsSsprCapable { get; set; }
    public bool? IsSsprEnabled { get; set; }
    public bool? IsSsprRegistered { get; set; }
    public bool? IsSystemPreferredAuthenticationMethodEnabled { get; set; }
    public DateTimeOffset? LastUpdatedDateTime { get; set; }
    public String[]? MethodsRegistered { get; set; }
    public String[]? SystemPreferredAuthenticationMethods { get; set; }
    public string? UserDisplayName { get; set; }
    public UserRegistrationDetailsUserDefaultAuthenticationMethod UserPreferredMethodForSecondaryAuthentication { get; set; }
    public string? UserPrincipalName { get; set; }
    public UserRegistrationDetailsSignInUserType UserType { get; set; }
}
