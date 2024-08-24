using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/plannerassignment?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerAssignment
    {
        public IdentitySet? AssignedBy { get; set; }
        public DateTimeOffset? AssignedDateTime { get; set; }
        public string? OrderHint { get; set; }
    }
}
