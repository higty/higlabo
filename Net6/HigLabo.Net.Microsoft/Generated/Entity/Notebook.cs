using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/notebook?view=graph-rest-1.0
    /// </summary>
    public partial class Notebook
    {
        public enum NotebookOnenoteUserRole
        {
            Owner,
            Contributor,
            Reader,
            None,
        }

        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsShared { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public NotebookLinks? Links { get; set; }
        public string? SectionGroupsUrl { get; set; }
        public string? SectionsUrl { get; set; }
        public string? Self { get; set; }
        public NotebookOnenoteUserRole UserRole { get; set; }
        public SectionGroup[]? SectionGroups { get; set; }
        public Section[]? Sections { get; set; }
    }
}
