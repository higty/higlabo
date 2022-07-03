using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-applepushnotificationcertificate?view=graph-rest-1.0
    /// </summary>
    public partial class ApplePushNotificationCertificate
    {
        public string Id { get; set; }
        public string AppleIdentifier { get; set; }
        public string TopicIdentifier { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset ExpirationDateTime { get; set; }
        public string CertificateSerialNumber { get; set; }
        public string Certificate { get; set; }
    }
}
