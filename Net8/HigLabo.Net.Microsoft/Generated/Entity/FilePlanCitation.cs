using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-fileplancitation?view=graph-rest-1.0
    /// </summary>
    public partial class FilePlanCitation
    {
        public string? CitationJurisdiction { get; set; }
        public string? CitationUrl { get; set; }
        public string? DisplayName { get; set; }
    }
}
