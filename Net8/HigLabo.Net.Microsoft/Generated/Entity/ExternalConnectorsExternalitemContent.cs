using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalitemcontent?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalItemContent
    {
        public enum ExternalConnectorsExternalItemContentExternalConnectorsExternalItemContentType
        {
            Text,
            Html,
            UnknownFutureValue,
        }

        public ExternalConnectorsExternalItemContentExternalConnectorsExternalItemContentType Type { get; set; }
        public string? Value { get; set; }
    }
}
