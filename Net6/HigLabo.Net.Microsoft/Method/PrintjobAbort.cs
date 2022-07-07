using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintjobAbortParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs_PrintJobId_Abort,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId_Abort: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}/abort";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Reason { get; set; }
        public string PrinterId { get; set; }
        public string PrintJobId { get; set; }
    }
    public partial class PrintjobAbortResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobAbortResponse> PrintjobAbortAsync()
        {
            var p = new PrintjobAbortParameter();
            return await this.SendAsync<PrintjobAbortParameter, PrintjobAbortResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobAbortResponse> PrintjobAbortAsync(CancellationToken cancellationToken)
        {
            var p = new PrintjobAbortParameter();
            return await this.SendAsync<PrintjobAbortParameter, PrintjobAbortResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobAbortResponse> PrintjobAbortAsync(PrintjobAbortParameter parameter)
        {
            return await this.SendAsync<PrintjobAbortParameter, PrintjobAbortResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobAbortResponse> PrintjobAbortAsync(PrintjobAbortParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintjobAbortParameter, PrintjobAbortResponse>(parameter, cancellationToken);
        }
    }
}
