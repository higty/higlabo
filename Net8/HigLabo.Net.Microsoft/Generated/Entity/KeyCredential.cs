using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/keycredential?view=graph-rest-1.0
/// </summary>
public partial class KeyCredential
{
    public string? CustomKeyIdentifier { get; set; }
    public string? DisplayName { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public string? Key { get; set; }
    public Guid? KeyId { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? Type { get; set; }
    public string? Usage { get; set; }
}
