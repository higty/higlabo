using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Id,
            DisplayName,
            Manufacturer,
            Model,
            RegisteredDateTime,
            Status,
            IsShared,
            HasPhysicalDevice,
            IsAcceptingJobs,
            Location,
            Defaults,
            Capabilities,
            LastSeenDateTime,
        }
        public enum ApiPath
        {
            Print_Printers_Id,
            Print_Shares_Id_Printer,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_Id: return $"/print/printers/{Id}";
                    case ApiPath.Print_Shares_Id_Printer: return $"/print/shares/{Id}/printer";
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
        public string Id { get; set; }
    }
    public partial class PrinterGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterGetResponse> PrinterGetAsync()
        {
            var p = new PrinterGetParameter();
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterGetResponse> PrinterGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterGetParameter();
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterGetResponse> PrinterGetAsync(PrinterGetParameter parameter)
        {
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterGetResponse> PrinterGetAsync(PrinterGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(parameter, cancellationToken);
        }
    }
}
