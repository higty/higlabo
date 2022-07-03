
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamworkuseridentity?view=graph-rest-1.0
    /// </summary>
    public enum TeamworkUserIdentityTeamworkUserIdentityType
    {
        AadUser,
        OnPremiseAadUser,
        AnonymousGuest,
        FederatedUser,
        PersonalMicrosoftAccountUser,
        SkypeUser,
        PhoneUser,
        UnknownFutureValue,
        EmailUser,
    }
}
