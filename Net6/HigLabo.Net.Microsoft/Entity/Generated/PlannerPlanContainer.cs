using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/plannerplancontainer?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerPlanContainer
    {
        public enum PlannerPlanContainerPlannerContainerType
        {
            Group,
            UnknownFutureValue,
            Roster,
        }

        public string? ContainerId { get; set; }
        public PlannerPlanContainerPlannerContainerType Type { get; set; }
        public string? Url { get; set; }
    }
}
