using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/subjectrightsrequestdetail?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectRightsRequestDetail
    {
        public Int64? ExcludedItemCount { get; set; }
        public KeyValuePair[]? InsightCounts { get; set; }
        public Int64? ItemCount { get; set; }
        public Int64? ItemNeedReview { get; set; }
        public KeyValuePair[]? ProductItemCounts { get; set; }
        public Int64? SignedOffItemCount { get; set; }
        public Int64? TotalItemSize { get; set; }
    }
}
