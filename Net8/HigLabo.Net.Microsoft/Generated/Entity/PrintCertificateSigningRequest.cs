using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/printcertificatesigningrequest?view=graph-rest-1.0
/// </summary>
public partial class PrintCertificateSigningRequest
{
    public string? Content { get; set; }
    public string? TransportKey { get; set; }
}
