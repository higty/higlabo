using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/plannerplan?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerPlan
    {
        public PlannerPlanContainer? Container { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Title { get; set; }
    }
}
