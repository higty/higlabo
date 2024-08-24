using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageresourcerole?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageResourceRole
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? OriginId { get; set; }
        public string? OriginSystem { get; set; }
        public AccessPackageResource? Resource { get; set; }
    }
}
