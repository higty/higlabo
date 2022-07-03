using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/externalconnectors-externalconnection?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnection
    {
        public Configuration Configuration { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public ExternalConnectionExternalConnectorsConnectionState State { get; set; }
    }
}
