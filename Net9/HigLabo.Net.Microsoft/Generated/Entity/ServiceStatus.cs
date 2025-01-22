using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/servicestatus?view=graph-rest-1.0
/// </summary>
public partial class ServiceStatus
{
    public enum ServiceStatusBackupServiceConsumer
    {
        Unknown,
        Firstparty,
        Thirdparty,
        UnknownFutureValue,
    }
    public enum ServiceStatusDisableReason
    {
        None,
        ControllerServiceAppDeleted,
        InvalidBillingProfile,
        UserRequested,
        UnknownFutureValue,
    }
    public enum ServiceStatusBackupServiceStatus
    {
        Disabled,
        Enabled,
        ProtectionChangeLocked,
        RestoreLocked,
        UnknownFutureValue,
    }

    public ServiceStatus? BackupServiceConsumer { get; set; }
    public ServiceStatusDisableReason DisableReason { get; set; }
    public DateTimeOffset? GracePeriodDateTime { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DateTimeOffset? RestoreAllowedTillDateTime { get; set; }
    public ServiceStatusBackupServiceStatus Status { get; set; }
}
