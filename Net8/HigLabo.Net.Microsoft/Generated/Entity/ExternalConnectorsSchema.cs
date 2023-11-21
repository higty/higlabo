using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-schema?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsSchema
    {
        public string? BaseType { get; set; }
        public ExternalConnectorsProperty[]? Properties { get; set; }
    }
}
