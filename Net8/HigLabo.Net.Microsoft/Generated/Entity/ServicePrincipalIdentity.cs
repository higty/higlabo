using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/serviceprincipalidentity?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalIdentity
    {
        public string? AppId { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
}
