using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterListSharesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Shares,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Shares: return $"/print/printers/{PrinterId}/shares";
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
    public partial class PrinterListSharesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printershare?view=graph-rest-1.0
        /// </summary>
        public partial class PrinterShare
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Manufacturer { get; set; }
            public string? Model { get; set; }
            public bool? IsAcceptingJobs { get; set; }
            public PrinterDefaults? Defaults { get; set; }
            public PrinterCapabilities? Capabilities { get; set; }
            public PrinterLocation? Location { get; set; }
            public PrinterStatus? Status { get; set; }
            public bool? AllowAllUsers { get; set; }
        }

        public PrinterShare[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync()
        {
            var p = new PrinterListSharesParameter();
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterListSharesParameter();
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync(PrinterListSharesParameter parameter)
        {
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync(PrinterListSharesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(parameter, cancellationToken);
        }
    }
}
