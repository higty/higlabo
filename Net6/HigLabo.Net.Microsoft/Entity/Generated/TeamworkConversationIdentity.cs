using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamworkconversationidentity?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworkConversationIdentity
    {
        public enum TeamworkConversationIdentityTeamworkConversationIdentityType
        {
            Team,
            Channel,
            Chat,
            UnknownFutureValue,
        }

        public TeamworkConversationIdentityTeamworkConversationIdentityType ConversationIdentityType { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
}
