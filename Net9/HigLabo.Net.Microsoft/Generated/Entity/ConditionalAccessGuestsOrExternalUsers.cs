using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessguestsorexternalusers?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessGuestsOrExternalUsers
{
    public enum ConditionalAccessGuestsOrExternalUsersConditionalAccessGuestOrExternalUserTypes
    {
        None,
        InternalGuest,
        B2bCollaborationGuest,
        B2bCollaborationMember,
        B2bDirectConnectUser,
        OtherExternalUser,
        ServiceProvider,
        UnknownFutureValue,
    }

    public ConditionalAccessExternalTenants? ExternalTenants { get; set; }
    public ConditionalAccessGuestsOrExternalUsersConditionalAccessGuestOrExternalUserTypes GuestOrExternalUserTypes { get; set; }
}
