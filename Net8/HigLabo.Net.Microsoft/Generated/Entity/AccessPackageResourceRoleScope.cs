using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageresourcerolescope?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageResourceRoleScope
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public AccessPackageResourceRole? Role { get; set; }
        public AccessPackageResourceScope? Scope { get; set; }
    }
}
