using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/claimsmappingpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class ClaimsMappingPolicy
    {
        public string? Id { get; set; }
        public String[]? Definition { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public bool? IsOrganizationDefault { get; set; }
        public DirectoryObject[]? AppliesTo { get; set; }
    }
}
