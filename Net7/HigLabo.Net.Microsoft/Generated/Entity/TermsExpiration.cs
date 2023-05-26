using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/termsexpiration?view=graph-rest-1.0
    /// </summary>
    public partial class TermsExpiration
    {
        public string? Frequency { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
    }
}
