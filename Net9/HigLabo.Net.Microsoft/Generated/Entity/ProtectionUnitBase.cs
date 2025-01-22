using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/protectionunitbase?view=graph-rest-1.0
/// </summary>
public partial class ProtectionUnitBase
{
    public enum ProtectionUnitBaseProtectionUnitStatus
    {
        ProtectRequested,
        Protected,
        UnprotectRequested,
        Unprotected,
        RemoveRequested,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public string? PolicyId { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public PublicError? Error { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public ProtectionUnitBase? Status { get; set; }
}
