using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintPostSharesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Shares,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares: return $"/print/shares";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Printer? Printer { get; set; }
        public string? DisplayName { get; set; }
        public bool? AllowAllUsers { get; set; }
    }
    public partial class PrintPostSharesResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostSharesResponse> PrintPostSharesAsync()
        {
            var p = new PrintPostSharesParameter();
            return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostSharesResponse> PrintPostSharesAsync(CancellationToken cancellationToken)
        {
            var p = new PrintPostSharesParameter();
            return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostSharesResponse> PrintPostSharesAsync(PrintPostSharesParameter parameter)
        {
            return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-post-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintPostSharesResponse> PrintPostSharesAsync(PrintPostSharesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintPostSharesParameter, PrintPostSharesResponse>(parameter, cancellationToken);
        }
    }
}
