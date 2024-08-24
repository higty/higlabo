using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageresourceattributequestion?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageResourceAttributeQuestion
    {
        public AccessPackageQuestion? Question { get; set; }
    }
}
