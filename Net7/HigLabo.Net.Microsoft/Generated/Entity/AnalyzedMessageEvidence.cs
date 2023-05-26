using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-analyzedmessageevidence?view=graph-rest-1.0
    /// </summary>
    public partial class AnalyzedMessageEvidence
    {
        public string? AntiSpamDirection { get; set; }
        public Int64? AttachmentsCount { get; set; }
        public string? DeliveryAction { get; set; }
        public string? DeliveryLocation { get; set; }
        public string? InternetMessageId { get; set; }
        public string? Language { get; set; }
        public string? NetworkMessageId { get; set; }
        public EmailSender? P1Sender { get; set; }
        public EmailSender? P2Sender { get; set; }
        public DateTimeOffset? ReceivedDateTime { get; set; }
        public string? RecipientEmailAddress { get; set; }
        public string? SenderIp { get; set; }
        public string? Subject { get; set; }
        public String[]? ThreatDetectionMethods { get; set; }
        public String[]? Threats { get; set; }
        public Int64? UrlCount { get; set; }
        public String[]? Urls { get; set; }
        public string? Urn { get; set; }
    }
}
