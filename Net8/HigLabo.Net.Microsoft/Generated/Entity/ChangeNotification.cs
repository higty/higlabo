using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/changenotification?view=graph-rest-1.0
/// </summary>
public partial class ChangeNotification
{
    public enum ChangeNotificationChangeType
    {
        Created,
        Updated,
        Deleted,
    }
    public enum ChangeNotificationLifecycleEventType
    {
        Missed,
        SubscriptionRemoved,
        ReauthorizationRequired,
    }

    public ChangeNotificationChangeType ChangeType { get; set; }
    public string? ClientState { get; set; }
    public ChangeNotificationEncryptedContent? EncryptedContent { get; set; }
    public string? Id { get; set; }
    public ChangeNotificationLifecycleEventType LifecycleEvent { get; set; }
    public string? Resource { get; set; }
    public ResourceData? ResourceData { get; set; }
    public DateTimeOffset? SubscriptionExpirationDateTime { get; set; }
    public Guid? SubscriptionId { get; set; }
    public Guid? TenantId { get; set; }
}
