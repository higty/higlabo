using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/invitationparticipantinfo?view=graph-rest-1.0
    /// </summary>
    public partial class InvitationParticipantInfo
    {
        public bool? Hidden { get; set; }
        public IdentitySet? Identity { get; set; }
        public string? ParticipantId { get; set; }
        public bool? RemoveFromDefaultAudioRoutingGroup { get; set; }
        public string? ReplacesCallId { get; set; }
    }
}
