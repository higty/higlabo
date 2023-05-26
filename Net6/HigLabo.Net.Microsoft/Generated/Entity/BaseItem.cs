using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/baseitem?view=graph-rest-1.0
    /// </summary>
    public partial class BaseItem
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? ETag { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public ItemReference? ParentReference { get; set; }
        public string? WebUrl { get; set; }
        public User? CreatedByUser { get; set; }
        public User? LastModifiedByUser { get; set; }
    }
}
