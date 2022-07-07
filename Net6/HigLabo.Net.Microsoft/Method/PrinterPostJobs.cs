using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterPostJobsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs: return $"/print/printers/{PrinterId}/jobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterId { get; set; }
    }
    public partial class PrinterPostJobsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public PrintJobStatus? Status { get; set; }
        public PrintJobConfiguration? Configuration { get; set; }
        public Boolean? IsFetchable { get; set; }
        public String? RedirectedFrom { get; set; }
        public String? RedirectedTo { get; set; }
        public UserIdentity? CreatedBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync()
        {
            var p = new PrinterPostJobsParameter();
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterPostJobsParameter();
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync(PrinterPostJobsParameter parameter)
        {
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync(PrinterPostJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(parameter, cancellationToken);
        }
    }
}
