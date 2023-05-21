using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/quota?view=graph-rest-1.0
    /// </summary>
    public partial class Quota
    {
        public Int64? Deleted { get; set; }
        public Int64? Remaining { get; set; }
        public string? State { get; set; }
        public StoragePlanInformation? StoragePlanInformation { get; set; }
        public Int64? Total { get; set; }
        public Int64? Used { get; set; }
    }
}
