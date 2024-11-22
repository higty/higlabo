using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/changenotificationencryptedcontent?view=graph-rest-1.0
/// </summary>
public partial class ChangeNotificationEncryptedContent
{
    public string? Data { get; set; }
    public string? DataKey { get; set; }
    public string? DataSignature { get; set; }
    public string? EncryptionCertificateId { get; set; }
    public string? EncryptionCertificateThumbprint { get; set; }
}
