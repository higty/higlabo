using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/x509certificateuserbinding?view=graph-rest-1.0
/// </summary>
public partial class X509CertificateUserBinding
{
    public Int32? Priority { get; set; }
    public string? UserProperty { get; set; }
    public string? X509CertificateField { get; set; }
}
