using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintListConnectorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Connectors,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Connectors: return $"/print/connectors";
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
    }
    public partial class PrintListConnectorsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync()
        {
            var p = new PrintListConnectorsParameter();
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListConnectorsParameter();
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync(PrintListConnectorsParameter parameter)
        {
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync(PrintListConnectorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(parameter, cancellationToken);
        }
    }
}
