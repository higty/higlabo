using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/microsoftauthenticatorauthenticationmethod?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftAuthenticatorAuthenticationMethod
    {
        public DateTimeOffset CreatedDateTime { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public string DeviceTag { get; set; }
        public string PhoneAppVersion { get; set; }
    }
}
