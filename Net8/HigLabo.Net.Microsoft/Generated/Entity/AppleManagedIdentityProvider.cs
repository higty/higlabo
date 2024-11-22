using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/applemanagedidentityprovider?view=graph-rest-1.0
/// </summary>
public partial class AppleManagedIdentityProvider
{
    public string? CertificateData { get; set; }
    public string? DeveloperId { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? KeyId { get; set; }
    public string? ServiceId { get; set; }
}
