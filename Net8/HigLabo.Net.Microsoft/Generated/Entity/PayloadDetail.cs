using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/payloaddetail?view=graph-rest-1.0
    /// </summary>
    public partial class PayloadDetail
    {
        public PayloadCoachmark[]? CoachMarks { get; set; }
        public string? Content { get; set; }
        public string? PhishingUrl { get; set; }
    }
}
