using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/fido2authenticationmethod?view=graph-rest-1.0
    /// </summary>
    public partial class Fido2AuthenticationMethod
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string AaGuid { get; set; }
        public string Model { get; set; }
        public String[] AttestationCertificates { get; set; }
        public Fido2AuthenticationMethodAttestationLevel AttestationLevel { get; set; }
    }
}
