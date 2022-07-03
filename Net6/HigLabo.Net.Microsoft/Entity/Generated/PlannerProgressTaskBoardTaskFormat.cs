using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/plannerprogresstaskboardtaskformat?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerProgressTaskBoardTaskFormat
    {
        public string Id { get; set; }
        public string OrderHint { get; set; }
    }
}
