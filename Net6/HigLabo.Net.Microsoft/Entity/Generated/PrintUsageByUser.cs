using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printusagebyuser?view=graph-rest-1.0
    /// </summary>
    public partial class PrintUsageByUser
    {
        public string? Id { get; set; }
        public string? UserPrincipalName { get; set; }
        public DateOnly? UsageDate { get; set; }
        public Int64? CompletedBlackAndWhiteJobCount { get; set; }
        public Int64? CompletedColorJobCount { get; set; }
        public Int64? IncompleteJobCount { get; set; }
    }
}
