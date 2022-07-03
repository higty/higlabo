using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessagepolicyviolation?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessagePolicyViolation
    {
        public ChatMessagePolicyViolationDlpActionType? DlpAction { get; set; }
        public String? JustificationText { get; set; }
        public ChatMessagePolicyTip PolicyTip { get; set; }
        public ChatMessagePolicyViolationUserActionType? UserAction { get; set; }
        public ChatMessagePolicyViolationVerdictDetailsType? VerdictDetails { get; set; }
    }
}
