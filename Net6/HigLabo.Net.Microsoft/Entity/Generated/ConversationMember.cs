using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/conversationmember?view=graph-rest-1.0
    /// </summary>
    public partial class ConversationMember
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string[]? Roles { get; set; }
        public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
    }
}
