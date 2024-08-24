using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/plannerexternalreference?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerExternalReference
    {
        public string? Alias { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? PreviewPriority { get; set; }
        public string? Type { get; set; }
    }
}
