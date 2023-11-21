using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/plannerassignedtotaskboardtaskformat?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerAssignedToTaskBoardTaskFormat
    {
        public string? Id { get; set; }
        public PlannerOrderHintsByAssignee? OrderHintsByAssignee { get; set; }
        public string? UnassignedOrderHint { get; set; }
    }
}
