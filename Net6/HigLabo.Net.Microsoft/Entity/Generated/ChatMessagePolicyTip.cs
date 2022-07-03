using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chatmessagepolicyviolationpolicytip?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessagePolicyTip
    {
        public String? ComplianceUrl { get; set; }
        public String? GeneralText { get; set; }
        public string[] MatchedConditionDescriptions { get; set; }
    }
}
