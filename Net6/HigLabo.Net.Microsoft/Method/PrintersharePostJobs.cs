using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintersharePostJobsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_Jobs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares_PrinterShareId_Jobs: return $"/print/shares/{PrinterShareId}/jobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterShareId { get; set; }
    }
    public partial class PrintersharePostJobsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostJobsResponse> PrintersharePostJobsAsync()
        {
            var p = new PrintersharePostJobsParameter();
            return await this.SendAsync<PrintersharePostJobsParameter, PrintersharePostJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostJobsResponse> PrintersharePostJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintersharePostJobsParameter();
            return await this.SendAsync<PrintersharePostJobsParameter, PrintersharePostJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostJobsResponse> PrintersharePostJobsAsync(PrintersharePostJobsParameter parameter)
        {
            return await this.SendAsync<PrintersharePostJobsParameter, PrintersharePostJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostJobsResponse> PrintersharePostJobsAsync(PrintersharePostJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintersharePostJobsParameter, PrintersharePostJobsResponse>(parameter, cancellationToken);
        }
    }
}
