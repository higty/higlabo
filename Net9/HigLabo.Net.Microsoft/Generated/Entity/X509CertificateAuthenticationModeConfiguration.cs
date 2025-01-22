using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/x509certificateauthenticationmodeconfiguration?view=graph-rest-1.0
/// </summary>
public partial class X509CertificateAuthenticationModeConfiguration
{
    public enum X509CertificateAuthenticationModeConfigurationX509CertificateAuthenticationMode
    {
        X509CertificateSingleFactor,
        X509CertificateMultiFactor,
        UnknownFutureValue,
    }

    public X509CertificateRule[]? Rules { get; set; }
    public X509CertificateAuthenticationModeConfigurationX509CertificateAuthenticationMode X509CertificateAuthenticationDefaultMode { get; set; }
}
