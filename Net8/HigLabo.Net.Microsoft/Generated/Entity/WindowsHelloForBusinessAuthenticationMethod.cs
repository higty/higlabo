using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/windowshelloforbusinessauthenticationmethod?view=graph-rest-1.0
/// </summary>
public partial class WindowsHelloForBusinessAuthenticationMethod
{
    public enum WindowsHelloForBusinessAuthenticationMethodAuthenticationMethodKeyStrength
    {
        Normal,
        Weak,
        Unknown,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public WindowsHelloForBusinessAuthenticationMethodAuthenticationMethodKeyStrength KeyStrength { get; set; }
    public Device? Device { get; set; }
}
