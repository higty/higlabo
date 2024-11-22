using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/passwordcredential?view=graph-rest-1.0
/// </summary>
public partial class PasswordCredential
{
    public string? CustomKeyIdentifier { get; set; }
    public string? DisplayName { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public string? Hint { get; set; }
    public Guid? KeyId { get; set; }
    public string? SecretText { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
}
