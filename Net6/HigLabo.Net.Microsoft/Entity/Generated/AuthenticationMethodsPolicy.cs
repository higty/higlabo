using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/authenticationmethodspolicy?view=graph-rest-1.0
    /// </summary>
    public partial class AuthenticationMethodsPolicy
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? PolicyVersion { get; set; }
        public RegistrationEnforcement? RegistrationEnforcement { get; set; }
    }
}
