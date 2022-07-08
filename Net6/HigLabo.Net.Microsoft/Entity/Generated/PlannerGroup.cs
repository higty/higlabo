using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/plannergroup?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerGroup
    {
        public string? Id { get; set; }
        public PlannerPlan[]? Plans { get; set; }
    }
}
