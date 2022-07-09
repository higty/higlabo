using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamworkuseridentity?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworkUserIdentity
    {
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

        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public TeamworkUserIdentityTeamworkUserIdentityType UserIdentityType { get; set; }
    }
}
