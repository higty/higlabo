using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/inviteparticipantsoperation?view=graph-rest-1.0
    /// </summary>
    public partial class InviteParticipantsOperation
    {
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public InvitationParticipantInfo[]? Participants { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public string? Status { get; set; }
    }
}
