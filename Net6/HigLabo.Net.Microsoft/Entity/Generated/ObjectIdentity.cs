using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/objectidentity?view=graph-rest-1.0
    /// </summary>
    public partial class ObjectIdentity
    {
        public string? SignInType { get; set; }
        public string? Issuer { get; set; }
        public string? IssuerAssignedId { get; set; }
    }
}
