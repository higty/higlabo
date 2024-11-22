using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/x509certificaterule?view=graph-rest-1.0
/// </summary>
public partial class X509CertificateRule
{
    public enum X509CertificateRuleX509CertificateAuthenticationMode
    {
        X509CertificateSingleFactor,
        X509CertificateMultiFactor,
        UnknownFutureValue,
    }
    public enum X509CertificateRuleX509CertificateRuleType
    {
        IssuerSubject,
        PolicyOID,
        UnknownFutureValue,
    }

    public string? Identifier { get; set; }
    public X509CertificateRuleX509CertificateAuthenticationMode X509CertificateAuthenticationMode { get; set; }
    public X509CertificateRuleX509CertificateRuleType X509CertificateRuleType { get; set; }
}
