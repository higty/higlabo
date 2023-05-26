using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printserviceendpoint?view=graph-rest-1.0
    /// </summary>
    public partial class PrintServiceEndpoint
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Uri { get; set; }
    }
}
