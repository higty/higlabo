using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/subscription?view=graph-rest-1.0
    /// </summary>
    public partial class Subscription
    {
        public string ApplicationId { get; set; }
        public string ChangeType { get; set; }
        public string ClientState { get; set; }
        public string CreatorId { get; set; }
        public string EncryptionCertificate { get; set; }
        public string EncryptionCertificateId { get; set; }
        public DateTimeOffset ExpirationDateTime { get; set; }
        public string Id { get; set; }
        public bool IncludeResourceData { get; set; }
        public string LatestSupportedTlsVersion { get; set; }
        public string LifecycleNotificationUrl { get; set; }
        public string NotificationQueryOptions { get; set; }
        public string NotificationUrl { get; set; }
        public string NotificationUrlAppId { get; set; }
        public string Resource { get; set; }
    }
}
