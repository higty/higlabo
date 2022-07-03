using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/resourcespecificpermissiongrant?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceSpecificPermissionGrant
    {
        public String? Id { get; set; }
        public DateTimeOffset DeletedDateTime { get; set; }
        public String? ClientId { get; set; }
        public String? ClientAppId { get; set; }
        public String? ResourceAppId { get; set; }
        public ResourceSpecificPermissionGrantString PermissionType { get; set; }
        public String? Permission { get; set; }
    }
}
