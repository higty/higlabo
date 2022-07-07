using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterListConnectorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Connectors,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Connectors: return $"/print/printers/{PrinterId}/connectors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string PrinterId { get; set; }
    }
    public partial class PrinterListConnectorsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printconnector?view=graph-rest-1.0
        /// </summary>
        public partial class PrintConnector
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? FullyQualifiedDomainName { get; set; }
            public string? OperatingSystem { get; set; }
            public string? AppVersion { get; set; }
            public PrinterLocation? Location { get; set; }
            public DateTimeOffset? RegisteredDateTime { get; set; }
            public UserIdentity? RegisteredBy { get; set; }
        }

        public PrintConnector[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListConnectorsResponse> PrinterListConnectorsAsync()
        {
            var p = new PrinterListConnectorsParameter();
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListConnectorsResponse> PrinterListConnectorsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterListConnectorsParameter();
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListConnectorsResponse> PrinterListConnectorsAsync(PrinterListConnectorsParameter parameter)
        {
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListConnectorsResponse> PrinterListConnectorsAsync(PrinterListConnectorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterListConnectorsParameter, PrinterListConnectorsResponse>(parameter, cancellationToken);
        }
    }
}
