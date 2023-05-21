using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/plannerbucket?view=graph-rest-1.0
    /// </summary>
    public partial class PlannerBucket
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? OrderHint { get; set; }
        public string? PlanId { get; set; }
        public PlannerTask[]? Tasks { get; set; }
    }
}
