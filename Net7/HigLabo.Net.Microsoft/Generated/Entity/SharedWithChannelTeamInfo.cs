using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/sharedwithchannelteaminfo?view=graph-rest-1.0
    /// </summary>
    public partial class SharedWithChannelTeamInfo
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHostTeam { get; set; }
        public string? TenantId { get; set; }
        public ConversationMember[]? AllowedMembers { get; set; }
    }
}
