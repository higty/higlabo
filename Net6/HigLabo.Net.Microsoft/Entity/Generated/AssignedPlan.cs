using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/assignedplan?view=graph-rest-1.0
    /// </summary>
    public partial class AssignedPlan
    {
        public DateTimeOffset? AssignedDateTime { get; set; }
        public string? CapabilityStatus { get; set; }
        public string? Service { get; set; }
        public Guid? ServicePlanId { get; set; }
    }
}
