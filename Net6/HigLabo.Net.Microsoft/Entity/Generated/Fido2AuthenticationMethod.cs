using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/fido2authenticationmethod?view=graph-rest-1.0
    /// </summary>
    public partial class Fido2AuthenticationMethod
    {
        public enum Fido2AuthenticationMethodAttestationLevel
        {
            Attested,
            NotAttested,
        }

        public string? AaGuid { get; set; }
        public String[]? AttestationCertificates { get; set; }
        public Fido2AuthenticationMethodAttestationLevel AttestationLevel { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Model { get; set; }
    }
}
