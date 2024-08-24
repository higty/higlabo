using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_Id: return $"/print/printers/{Id}";
                    case ApiPath.Print_Shares_Id_Printer: return $"/print/shares/{Id}/printer";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_Id,
            Print_Shares_Id_Printer,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class PrinterGetResponse : RestApiResponse
    {
        public PrinterCapabilities? Capabilities { get; set; }
        public PrinterDefaults? Defaults { get; set; }
        public string? DisplayName { get; set; }
        public bool? HasPhysicalDevice { get; set; }
        public string? Id { get; set; }
        public bool? IsAcceptingJobs { get; set; }
        public bool? IsShared { get; set; }
        public DateTimeOffset? LastSeenDateTime { get; set; }
        public PrinterLocation? Location { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public DateTimeOffset? RegisteredDateTime { get; set; }
        public PrinterStatus? Status { get; set; }
        public PrintConnector? Connectors { get; set; }
        public PrintJob[]? Jobs { get; set; }
        public PrinterShare[]? Shares { get; set; }
        public PrintTaskTrigger[]? TaskTriggers { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterGetResponse> PrinterGetAsync()
        {
            var p = new PrinterGetParameter();
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterGetResponse> PrinterGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterGetParameter();
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterGetResponse> PrinterGetAsync(PrinterGetParameter parameter)
        {
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterGetResponse> PrinterGetAsync(PrinterGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterGetParameter, PrinterGetResponse>(parameter, cancellationToken);
        }
    }
}
