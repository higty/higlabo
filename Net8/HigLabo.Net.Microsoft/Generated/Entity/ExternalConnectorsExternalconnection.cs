using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalconnection?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalconnection
    {
        public enum ExternalConnectorsExternalconnectionExternalConnectorsConnectionState
        {
            Draft,
            Ready,
            Obsolete,
            LimitExceeded,
            UnknownFutureValue,
        }

        public ExternalConnectorsActivitySettings? ActivitySettings { get; set; }
        public ExternalConnectorsConfiguration? Configuration { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public ExternalConnectorsSearchSettings? SearchSettings { get; set; }
        public ExternalConnectorsExternalconnectionExternalConnectorsConnectionState State { get; set; }
        public ExternalConnectorsExternalitem[]? Items { get; set; }
        public ExternalConnectorsConnectionOperation[]? Operations { get; set; }
        public ExternalConnectorsSchema? Schema { get; set; }
    }
}
