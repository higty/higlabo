using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/domainidentitysource?view=graph-rest-1.0
    /// </summary>
    public partial class DomainIdentitySource
    {
        public string? DisplayName { get; set; }
        public string? DomainName { get; set; }
    }
}
