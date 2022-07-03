using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sharinginvitation?view=graph-rest-1.0
    /// </summary>
    public partial class SharingInvitation
    {
        public string Email { get; set; }
        public IdentitySet? InvitedBy { get; set; }
        public bool SignInRequired { get; set; }
    }
}
