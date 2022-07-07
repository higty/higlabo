using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/signinstatus?view=graph-rest-1.0
    /// </summary>
    public partial class SignInStatus
    {
        public string? AdditionalDetails { get; set; }
        public Int32? ErrorCode { get; set; }
        public string? FailureReason { get; set; }
    }
}
