using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/chatmessagepolicyviolationpolicytip?view=graph-rest-1.0
    /// </summary>
    public partial class ChatMessagePolicyTip
    {
        public string? ComplianceUrl { get; set; }
        public string? GeneralText { get; set; }
        public string[]? MatchedConditionDescriptions { get; set; }
    }
}
