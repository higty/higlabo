using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/userregistrationfeaturecount?view=graph-rest-1.0
    /// </summary>
    public partial class UserRegistrationFeatureCount
    {
        public enum UserRegistrationFeatureCountAuthenticationMethodFeature
        {
            SsprRegistered,
            SsprEnabled,
            SsprCapable,
            PasswordlessCapable,
            MfaCapable,
            UnknownFutureValue,
        }

        public UserRegistrationFeatureCountAuthenticationMethodFeature Feature { get; set; }
        public Int64? UserCount { get; set; }
    }
}
