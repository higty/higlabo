using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/invitedusermessageinfo?view=graph-rest-1.0
    /// </summary>
    public partial class InvitedUserMessageInfo
    {
        public Recipient[]? CcRecipients { get; set; }
        public string? CustomizedMessageBody { get; set; }
        public string? MessageLanguage { get; set; }
    }
}
