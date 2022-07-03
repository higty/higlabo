using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/emailauthenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class EmailAuthenticationMethodConfiguration
    {
        public string Id { get; set; }
        public EmailAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public EmailAuthenticationMethodConfigurationExternalEmailOtpState AllowExternalIdToUseEmailOtp { get; set; }
    }
}
