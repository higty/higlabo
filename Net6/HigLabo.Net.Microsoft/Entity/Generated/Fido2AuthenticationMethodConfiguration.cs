using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/fido2authenticationmethodconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class Fido2AuthenticationMethodConfiguration
    {
        public enum Fido2AuthenticationMethodConfigurationAuthenticationMethodState
        {
            Enabled,
            Disabled,
        }

        public string? Id { get; set; }
        public bool? IsAttestationEnforced { get; set; }
        public bool? IsSelfServiceRegistrationAllowed { get; set; }
        public Fido2KeyRestrictions? KeyRestrictions { get; set; }
        public Fido2AuthenticationMethodConfigurationAuthenticationMethodState State { get; set; }
        public AuthenticationMethodTarget[]? IncludeTargets { get; set; }
    }
}
