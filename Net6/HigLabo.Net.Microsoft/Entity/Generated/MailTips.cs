using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/mailtips?view=graph-rest-1.0
    /// </summary>
    public partial class MailTips
    {
        public enum MailTipsRecipientScopeType
        {
            None,
            Internal,
            External,
            ExternalPartner,
            ExternalNonParther,
        }

        public AutomaticRepliesMailTips? AutomaticReplies { get; set; }
        public string? CustomMailTip { get; set; }
        public bool? DeliveryRestricted { get; set; }
        public EmailAddress? EmailAddress { get; set; }
        public MailTipsError? Error { get; set; }
        public Int32? ExternalMemberCount { get; set; }
        public bool? IsModerated { get; set; }
        public bool? MailboxFull { get; set; }
        public Int32? MaxMessageSize { get; set; }
        public MailTipsRecipientScopeType RecipientScope { get; set; }
        public Recipient[]? RecipientSuggestions { get; set; }
        public Int32? TotalMemberCount { get; set; }
    }
}
