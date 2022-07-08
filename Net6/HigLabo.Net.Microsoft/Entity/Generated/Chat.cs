using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chat?view=graph-rest-1.0
    /// </summary>
    public partial class Chat
    {
        public enum ChatChatType
        {
            Group,
            OneOnOne,
            Meeting,
            UnknownFutureValue,
        }

        public Chat? ChatType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        public TeamworkOnlineMeetingInfo? OnlineMeetingInfo { get; set; }
        public string? TenantId { get; set; }
        public string? Topic { get; set; }
        public string? WebUrl { get; set; }
        public TeamsAppInstallation[]? InstalledApps { get; set; }
        public ConversationMember[]? Members { get; set; }
        public ChatMessage[]? Messages { get; set; }
        public TeamsTab[]? Tabs { get; set; }
    }
}
