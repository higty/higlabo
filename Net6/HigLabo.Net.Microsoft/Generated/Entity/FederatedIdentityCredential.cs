using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/federatedidentitycredential?view=graph-rest-1.0
    /// </summary>
    public partial class FederatedIdentityCredential
    {
        public String[]? Audiences { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Issuer { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
    }
}
