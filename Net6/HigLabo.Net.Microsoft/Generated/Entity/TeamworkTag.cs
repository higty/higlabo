using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teamworktag?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworkTag
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public Int32? MemberCount { get; set; }
        public TeamworkTag? TagType { get; set; }
        public string? TeamId { get; set; }
        public TeamworkTagMember[]? Members { get; set; }
    }
}
