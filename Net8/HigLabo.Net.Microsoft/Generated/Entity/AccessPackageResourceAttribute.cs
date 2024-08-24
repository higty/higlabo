using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageresourceattribute?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageResourceAttribute
    {
        public AccessPackageResourceAttributeDestination? Destination { get; set; }
        public string? Name { get; set; }
        public AccessPackageResourceAttributeSource? Source { get; set; }
    }
}
