using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintershareGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrinterShareId { get; set; }
            public string PrinterId { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId: return $"/print/shares/{PrinterShareId}";
                    case ApiPath.Print_Printers_PrinterId_Shares_PrinterShareId: return $"/print/printers/{PrinterId}/shares/{PrinterShareId}";
                    case ApiPath.Print_Printers_Id: return $"/print/printers/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Shares_PrinterShareId,
            Print_Printers_PrinterId_Shares_PrinterShareId,
            Print_Printers_Id,
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
    public partial class PrintershareGetResponse : RestApiResponse
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
        public Printer? Printer { get; set; }
        public User[]? AllowedUsers { get; set; }
        public Group? AllowedGroups { get; set; }
        public PrintJob[]? Jobs { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareGetResponse> PrintershareGetAsync()
        {
            var p = new PrintershareGetParameter();
            return await this.SendAsync<PrintershareGetParameter, PrintershareGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareGetResponse> PrintershareGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareGetParameter();
            return await this.SendAsync<PrintershareGetParameter, PrintershareGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareGetResponse> PrintershareGetAsync(PrintershareGetParameter parameter)
        {
            return await this.SendAsync<PrintershareGetParameter, PrintershareGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareGetResponse> PrintershareGetAsync(PrintershareGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareGetParameter, PrintershareGetResponse>(parameter, cancellationToken);
        }
    }
}
