using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintListPrintersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers: return $"/print/printers";
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
    public partial class PrintListPrintersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printer?view=graph-rest-1.0
        /// </summary>
        public partial class Printer
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Manufacturer { get; set; }
            public string? Model { get; set; }
            public DateTimeOffset? RegisteredDateTime { get; set; }
            public PrinterStatus? Status { get; set; }
            public bool? IsShared { get; set; }
            public bool? HasPhysicalDevice { get; set; }
            public bool? IsAcceptingJobs { get; set; }
            public PrinterLocation? Location { get; set; }
            public PrinterDefaults? Defaults { get; set; }
            public PrinterCapabilities? Capabilities { get; set; }
            public DateTimeOffset? LastSeenDateTime { get; set; }
        }

        public Printer[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync()
        {
            var p = new PrintListPrintersParameter();
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListPrintersParameter();
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter)
        {
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, cancellationToken);
        }
    }
}
