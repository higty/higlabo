using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/directoryrole?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryRole
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? RoleTemplateId { get; set; }
        public DirectoryObject[]? Members { get; set; }
        public ScopedRoleMembership[]? ScopedMembers { get; set; }
    }
}
