using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/messagerulepredicates?view=graph-rest-1.0
    /// </summary>
    public partial class MessageRulePredicates
    {
        public enum MessageRulePredicatesImportance
        {
            Low,
            Normal,
            High,
        }
        public enum MessageRulePredicatesMessageActionFlag
        {
            Any,
            Call,
            DoNotForward,
            FollowUp,
            Fyi,
            Forward,
            NoResponseNecessary,
            Read,
            Reply,
            ReplyToAll,
            Review,
        }
        public enum MessageRulePredicatesSensitivity
        {
            Normal,
            Personal,
            Private,
            Confidential,
        }

        public String[]? BodyContains { get; set; }
        public String[]? BodyOrSubjectContains { get; set; }
        public String[]? Categories { get; set; }
        public Recipient[]? FromAddresses { get; set; }
        public bool? HasAttachments { get; set; }
        public String[]? HeaderContains { get; set; }
        public MessageRulePredicatesImportance Importance { get; set; }
        public bool? IsApprovalRequest { get; set; }
        public bool? IsAutomaticForward { get; set; }
        public bool? IsAutomaticReply { get; set; }
        public bool? IsEncrypted { get; set; }
        public bool? IsMeetingRequest { get; set; }
        public bool? IsMeetingResponse { get; set; }
        public bool? IsNonDeliveryReport { get; set; }
        public bool? IsPermissionControlled { get; set; }
        public bool? IsReadReceipt { get; set; }
        public bool? IsSigned { get; set; }
        public bool? IsVoicemail { get; set; }
        public MessageRulePredicatesMessageActionFlag MessageActionFlag { get; set; }
        public bool? NotSentToMe { get; set; }
        public String[]? RecipientContains { get; set; }
        public String[]? SenderContains { get; set; }
        public MessageRulePredicatesSensitivity Sensitivity { get; set; }
        public bool? SentCcMe { get; set; }
        public bool? SentOnlyToMe { get; set; }
        public Recipient[]? SentToAddresses { get; set; }
        public bool? SentToMe { get; set; }
        public bool? SentToOrCcMe { get; set; }
        public String[]? SubjectContains { get; set; }
        public SizeRange? WithinSizeRange { get; set; }
    }
}
