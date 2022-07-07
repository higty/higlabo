using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/plannerplandetails?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerPlanDetails
    {
        public PlannerCategoryDescriptions? CategoryDescriptions { get; set; }
        public string? Id { get; set; }
        public PlannerUserIds? SharedWith { get; set; }
    }
}
