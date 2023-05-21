using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/resourcespecificpermissiongrant?view=graph-rest-1.0
    /// </summary>
    public partial class ResourceSpecificPermissionGrant
    {
        public enum ResourceSpecificPermissionGrantstring
        {
            Application,
            Delegated,
        }

        public string? ClientId { get; set; }
        public string? ClientAppId { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
        public string? ResourceAppId { get; set; }
        public ResourceSpecificPermissionGrantstring PermissionType { get; set; }
        public string? Permission { get; set; }
    }
}
