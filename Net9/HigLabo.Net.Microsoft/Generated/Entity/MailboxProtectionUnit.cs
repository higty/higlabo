using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/mailboxprotectionunit?view=graph-rest-1.0
/// </summary>
public partial class MailboxProtectionUnit
{
    public enum MailboxProtectionUnitProtectionUnitStatus
    {
        ProtectRequested,
        Protected,
        UnprotectRequested,
        Unprotected,
        RemoveRequested,
        UnknownFutureValue,
    }

    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DirectoryObjectId { get; set; }
    public string? DisplayName { get; set; }
    public string? Email { get; set; }
    public PublicError? Error { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? PolicyId { get; set; }
    public MailboxProtectionUnit? Status { get; set; }
}
