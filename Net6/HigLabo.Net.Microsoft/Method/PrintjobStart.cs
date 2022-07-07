using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintjobStartParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_Jobs_PrintJobId_Start,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares_PrinterShareId_Jobs_PrintJobId_Start: return $"/print/shares/{PrinterShareId}/jobs/{PrintJobId}/start";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterShareId { get; set; }
        public string PrintJobId { get; set; }
    }
    public partial class PrintjobStartResponse : RestApiResponse
    {
        public PrintJobProcessingState? State { get; set; }
        public PrintJobProcessingDetail[]? Details { get; set; }
        public string? Description { get; set; }
        public bool? IsAcquiredByPrinter { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-start?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobStartResponse> PrintjobStartAsync()
        {
            var p = new PrintjobStartParameter();
            return await this.SendAsync<PrintjobStartParameter, PrintjobStartResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-start?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobStartResponse> PrintjobStartAsync(CancellationToken cancellationToken)
        {
            var p = new PrintjobStartParameter();
            return await this.SendAsync<PrintjobStartParameter, PrintjobStartResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-start?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobStartResponse> PrintjobStartAsync(PrintjobStartParameter parameter)
        {
            return await this.SendAsync<PrintjobStartParameter, PrintjobStartResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-start?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobStartResponse> PrintjobStartAsync(PrintjobStartParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintjobStartParameter, PrintjobStartResponse>(parameter, cancellationToken);
        }
    }
}
