using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamstabconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsTabConfiguration
    {
        public String? EntityId { get; set; }
        public String? ContentUrl { get; set; }
        public String? RemoveUrl { get; set; }
        public String? WebsiteUrl { get; set; }
    }
}
