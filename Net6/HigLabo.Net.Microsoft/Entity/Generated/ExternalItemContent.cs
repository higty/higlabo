using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/externalconnectors-externalitemcontent?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalItemContent
    {
        public enum ExternalItemContentExternalConnectorsExternalItemContentType
        {
            Text,
            Html,
            UnknownFutureValue,
        }

        public ExternalItemContentExternalConnectorsExternalItemContentType Type { get; set; }
        public string? Value { get; set; }
    }
}
