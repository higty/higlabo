using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/rubricquality?view=graph-rest-1.0
    /// </summary>
    public partial class RubricQuality
    {
        public RubricCriterion[]? Criteria { get; set; }
        public ItemBody? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? QualityId { get; set; }
        public Single? Weight { get; set; }
    }
}
