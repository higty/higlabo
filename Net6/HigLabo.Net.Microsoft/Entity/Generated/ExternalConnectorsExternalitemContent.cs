using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalitemcontent?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalitemContent
    {
        public enum ExternalConnectorsExternalitemContentExternalConnectorsExternalItemContentType
        {
            Text,
            Html,
            UnknownFutureValue,
        }

        public ExternalConnectorsExternalitemContentExternalConnectorsExternalItemContentType Type { get; set; }
        public string? Value { get; set; }
    }
}
