using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
    /// </summary>
    public partial class PrintJobAbortParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }
            public string? PrintJobId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId_Abort: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}/abort";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs_PrintJobId_Abort,
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
        public string? Reason { get; set; }
    }
    public partial class PrintJobAbortResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintJobAbortResponse> PrintJobAbortAsync()
        {
            var p = new PrintJobAbortParameter();
            return await this.SendAsync<PrintJobAbortParameter, PrintJobAbortResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintJobAbortResponse> PrintJobAbortAsync(CancellationToken cancellationToken)
        {
            var p = new PrintJobAbortParameter();
            return await this.SendAsync<PrintJobAbortParameter, PrintJobAbortResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintJobAbortResponse> PrintJobAbortAsync(PrintJobAbortParameter parameter)
        {
            return await this.SendAsync<PrintJobAbortParameter, PrintJobAbortResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-abort?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintJobAbortResponse> PrintJobAbortAsync(PrintJobAbortParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintJobAbortParameter, PrintJobAbortResponse>(parameter, cancellationToken);
        }
    }
}
