using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/oauthconsentappdetail?view=graph-rest-1.0
/// </summary>
public partial class OAuthConsentAppDetail
{
    public enum OAuthConsentAppDetailOAuthAppScope
    {
        Unknown,
        ReadCalendar,
        ReadContact,
        ReadMail,
        ReadAllChat,
        ReadAllFile,
        ReadAndWriteMail,
        SendMail,
        UnknownFutureValue,
    }

    public OAuthConsentAppDetailOAuthAppScope AppScope { get; set; }
    public string? DisplayLogo { get; set; }
    public string? DisplayName { get; set; }
}
