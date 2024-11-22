using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/restorepoint?view=graph-rest-1.0
/// </summary>
public partial class ReStorePoint
{
    public enum ReStorePointRestorePointTags
    {
        None,
        FastRestore,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public DateTimeOffset? ProtectionDateTime { get; set; }
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public ReStorePoint? Tags { get; set; }
    public ProtectionUnitBase? ProtectionUnit { get; set; }
}
