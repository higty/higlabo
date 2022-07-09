using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/channel?view=graph-rest-1.0
    /// </summary>
    public partial class Channel
    {
        public enum ChannelChannelMembershipType
        {
            Standard,
            Private,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsFavoriteByDefault { get; set; }
        public string? Email { get; set; }
        public string? WebUrl { get; set; }
        public ChannelChannelMembershipType MembershipType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ChatMessage[]? Messages { get; set; }
        public TeamsTab[]? Tabs { get; set; }
        public ConversationMember[]? Members { get; set; }
        public DriveItem? FilesFolder { get; set; }
        public TeamsASyncOperation[]? Operations { get; set; }
    }
}
