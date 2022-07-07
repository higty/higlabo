using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintjobRedirectParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs_PrintJobId_Redirect,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId_Redirect: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}/redirect";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DestinationPrinterId { get; set; }
        public PrintJobConfiguration? Configuration { get; set; }
        public string PrinterId { get; set; }
        public string PrintJobId { get; set; }
    }
    public partial class PrintjobRedirectResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/printjob-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobRedirectResponse> PrintjobRedirectAsync()
        {
            var p = new PrintjobRedirectParameter();
            return await this.SendAsync<PrintjobRedirectParameter, PrintjobRedirectResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobRedirectResponse> PrintjobRedirectAsync(CancellationToken cancellationToken)
        {
            var p = new PrintjobRedirectParameter();
            return await this.SendAsync<PrintjobRedirectParameter, PrintjobRedirectResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobRedirectResponse> PrintjobRedirectAsync(PrintjobRedirectParameter parameter)
        {
            return await this.SendAsync<PrintjobRedirectParameter, PrintjobRedirectResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-redirect?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobRedirectResponse> PrintjobRedirectAsync(PrintjobRedirectParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintjobRedirectParameter, PrintjobRedirectResponse>(parameter, cancellationToken);
        }
    }
}
