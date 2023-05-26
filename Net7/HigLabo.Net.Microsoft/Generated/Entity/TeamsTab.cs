using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teamstab?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsTab
    {
        public TeamsTabConfiguration? Configuration { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
        public TeamsApp? TeamsApp { get; set; }
    }
}
