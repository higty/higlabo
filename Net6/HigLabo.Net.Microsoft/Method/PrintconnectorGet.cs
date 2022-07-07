using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintconnectorGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Connectors_PrintConnectorId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Connectors_PrintConnectorId: return $"/print/connectors/{PrintConnectorId}";
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
        public string PrintConnectorId { get; set; }
    }
    public partial class PrintconnectorGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorGetResponse> PrintconnectorGetAsync()
        {
            var p = new PrintconnectorGetParameter();
            return await this.SendAsync<PrintconnectorGetParameter, PrintconnectorGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorGetResponse> PrintconnectorGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintconnectorGetParameter();
            return await this.SendAsync<PrintconnectorGetParameter, PrintconnectorGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorGetResponse> PrintconnectorGetAsync(PrintconnectorGetParameter parameter)
        {
            return await this.SendAsync<PrintconnectorGetParameter, PrintconnectorGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorGetResponse> PrintconnectorGetAsync(PrintconnectorGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintconnectorGetParameter, PrintconnectorGetResponse>(parameter, cancellationToken);
        }
    }
}
