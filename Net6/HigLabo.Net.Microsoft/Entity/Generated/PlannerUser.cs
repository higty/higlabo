using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/planneruser?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerUser
    {
        public string? Id { get; set; }
        public PlannerPlan[]? Plans { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
}
