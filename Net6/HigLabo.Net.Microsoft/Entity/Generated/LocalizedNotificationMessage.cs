using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-notification-localizednotificationmessage?view=graph-rest-1.0
    /// </summary>
    public partial class LocalizedNotificationMessage
    {
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string Locale { get; set; }
        public string Subject { get; set; }
        public string MessageTemplate { get; set; }
        public bool IsDefault { get; set; }
    }
}
