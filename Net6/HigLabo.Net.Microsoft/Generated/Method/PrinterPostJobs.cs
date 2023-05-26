using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterPostJobsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs: return $"/print/printers/{PrinterId}/jobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public PrintJobConfiguration? Configuration { get; set; }
        public UserIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public Boolean? IsFetchable { get; set; }
        public String? RedirectedFrom { get; set; }
        public String? RedirectedTo { get; set; }
        public PrintJobStatus? Status { get; set; }
        public PrintDocument[]? Documents { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
    public partial class PrinterPostJobsResponse : RestApiResponse
    {
        public PrintJobConfiguration? Configuration { get; set; }
        public UserIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public Boolean? IsFetchable { get; set; }
        public String? RedirectedFrom { get; set; }
        public String? RedirectedTo { get; set; }
        public PrintJobStatus? Status { get; set; }
        public PrintDocument[]? Documents { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync()
        {
            var p = new PrinterPostJobsParameter();
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterPostJobsParameter();
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync(PrinterPostJobsParameter parameter)
        {
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-post-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostJobsResponse> PrinterPostJobsAsync(PrinterPostJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterPostJobsParameter, PrinterPostJobsResponse>(parameter, cancellationToken);
        }
    }
}
