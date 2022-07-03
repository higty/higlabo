using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/plannertaskdetails?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerTaskDetails
    {
        public PlannerChecklistItems? Checklist { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public PlannerTaskDetailsString PreviewType { get; set; }
        public PlannerExternalReferences? References { get; set; }
    }
}
