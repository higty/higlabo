using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sectiongroup?view=graph-rest-1.0
    /// </summary>
    public partial class SectionGroup
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string DisplayName { get; set; }
        public string SectionGroupsUrl { get; set; }
        public string SectionsUrl { get; set; }
        public string Self { get; set; }
    }
}
