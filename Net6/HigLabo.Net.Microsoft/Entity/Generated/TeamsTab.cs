using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamstab?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsTab
    {
        public String? Id { get; set; }
        public String? DisplayName { get; set; }
        public String? WebUrl { get; set; }
        public TeamsTabConfiguration? Configuration { get; set; }
    }
}
