using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/x509certificateauthenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class X509CertificateAuthenticationMethodConfiguration
    {
        public enum X509CertificateAuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public X509CertificateAuthenticationModeConfiguration? AuthenticationModeConfiguration { get; set; }
        public X509CertificateUserBinding[]? CertificateUserBindings { get; set; }
        public ExcludeTarget[]? ExcludeTargets { get; set; }
        public string? Id { get; set; }
        public X509CertificateAuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
}
