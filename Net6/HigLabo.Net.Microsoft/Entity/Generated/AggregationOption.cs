using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/aggregationoption?view=graph-rest-1.0
    /// </summary>
    public partial class AggregationOption
    {
        public BucketAggregationDefinition? BucketDefinition { get; set; }
        public string? Field { get; set; }
        public Int32? Size { get; set; }
    }
}
