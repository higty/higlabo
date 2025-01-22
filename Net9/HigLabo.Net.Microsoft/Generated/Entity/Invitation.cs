using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/invitation?view=graph-rest-1.0
/// </summary>
public partial class Invitation
{
    public string? InvitedUserDisplayName { get; set; }
    public string? InvitedUserEmailAddress { get; set; }
    public InvitedUserMessageInfo? InvitedUserMessageInfo { get; set; }
    public string? InvitedUserType { get; set; }
    public string? InviteRedirectUrl { get; set; }
    public string? InviteRedeemUrl { get; set; }
    public bool? ResetRedemption { get; set; }
    public bool? SendInvitationMessage { get; set; }
    public string? Status { get; set; }
    public User? InvitedUser { get; set; }
}
