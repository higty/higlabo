using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamsapp?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsApp
    {
        public String? Id { get; set; }
        public String? ExternalId { get; set; }
        public String? DisplayName { get; set; }
        public TeamsAppDistributionMethod? DistributionMethod { get; set; }
    }
}
