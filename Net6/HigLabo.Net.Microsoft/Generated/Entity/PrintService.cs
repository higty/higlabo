using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printservice?view=graph-rest-1.0
    /// </summary>
    public partial class PrintService
    {
        public string? Id { get; set; }
        public PrintServiceEndpoint[]? Endpoints { get; set; }
    }
}
