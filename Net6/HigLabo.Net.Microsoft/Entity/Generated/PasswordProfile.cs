using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/passwordprofile?view=graph-rest-1.0
    /// </summary>
    public partial class PasswordProfile
    {
        public bool ForceChangePasswordNextSignIn { get; set; }
        public bool ForceChangePasswordNextSignInWithMfa { get; set; }
        public string Password { get; set; }
    }
}
