using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/permission?view=graph-rest-1.0
    /// </summary>
    public partial class Permission
    {
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string? Id { get; set; }
        public bool? HasPassword { get; set; }
        public SharePointIdentitySet[]? GrantedToIdentitiesV2 { get; set; }
        public SharePointIdentitySet? GrantedToV2 { get; set; }
        public ItemReference? InheritedFrom { get; set; }
        public SharingInvitation? Invitation { get; set; }
        public SharingLink? Link { get; set; }
        public string[]? Roles { get; set; }
        public string? ShareId { get; set; }
    }
}
