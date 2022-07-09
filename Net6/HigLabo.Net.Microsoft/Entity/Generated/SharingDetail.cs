using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/insights-sharingdetail?view=graph-rest-1.0
    /// </summary>
    public partial class SharingDetail
    {
        public DateTimeOffset? SharedDateTime { get; set; }
        public string? SharingSubject { get; set; }
        public string? SharingType { get; set; }
        public InsightIdentity? SharedBy { get; set; }
        public ResourceReference? SharingReference { get; set; }
    }
}
