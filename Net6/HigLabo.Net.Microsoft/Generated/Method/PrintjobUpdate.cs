using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printjob-update?view=graph-rest-1.0
    /// </summary>
    public partial class PrintjobUpdateParameter : IRestApiParameter
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
                    case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs_PrintJobId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class PrintjobUpdateResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/printjob-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobUpdateResponse> PrintjobUpdateAsync()
        {
            var p = new PrintjobUpdateParameter();
            return await this.SendAsync<PrintjobUpdateParameter, PrintjobUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobUpdateResponse> PrintjobUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PrintjobUpdateParameter();
            return await this.SendAsync<PrintjobUpdateParameter, PrintjobUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobUpdateResponse> PrintjobUpdateAsync(PrintjobUpdateParameter parameter)
        {
            return await this.SendAsync<PrintjobUpdateParameter, PrintjobUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printjob-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobUpdateResponse> PrintjobUpdateAsync(PrintjobUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintjobUpdateParameter, PrintjobUpdateResponse>(parameter, cancellationToken);
        }
    }
}
