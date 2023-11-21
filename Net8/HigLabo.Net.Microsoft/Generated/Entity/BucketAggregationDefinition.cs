using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bucketaggregationdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class BucketAggregationDefinition
    {
        public enum BucketAggregationDefinitionBucketAggregationSortProperty
        {
            Count,
            KeyAsString,
            KeyAsNumber,
        }

        public bool? IsDescending { get; set; }
        public Int32? MinimumCount { get; set; }
        public string? PrefixFilter { get; set; }
        public BucketAggregationRange[]? Ranges { get; set; }
        public BucketAggregationDefinitionBucketAggregationSortProperty SortBy { get; set; }
    }
}
