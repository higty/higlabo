using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintjobCancelParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs_PrintJobId_Cancel,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId_Cancel: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterId { get; set; }
        public string PrintJobId { get; set; }
    }
    public partial class PrintjobCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobCancelResponse> PrintjobCancelAsync()
        {
            var p = new PrintjobCancelParameter();
            return await this.SendAsync<PrintjobCancelParameter, PrintjobCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobCancelResponse> PrintjobCancelAsync(CancellationToken cancellationToken)
        {
            var p = new PrintjobCancelParameter();
            return await this.SendAsync<PrintjobCancelParameter, PrintjobCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobCancelResponse> PrintjobCancelAsync(PrintjobCancelParameter parameter)
        {
            return await this.SendAsync<PrintjobCancelParameter, PrintjobCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobCancelResponse> PrintjobCancelAsync(PrintjobCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintjobCancelParameter, PrintjobCancelResponse>(parameter, cancellationToken);
        }
    }
}
