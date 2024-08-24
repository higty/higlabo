using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-urlmatchinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsUrlmatchinfo
    {
        public String[]? BaseUrls { get; set; }
        public string? UrlPattern { get; set; }
    }
}
