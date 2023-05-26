using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterDeleteTasktriggerParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }
            public string? PrintTaskTriggerId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_TaskTriggers_PrintTaskTriggerId: return $"/print/printers/{PrinterId}/taskTriggers/{PrintTaskTriggerId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId_TaskTriggers_PrintTaskTriggerId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class PrinterDeleteTasktriggerResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync()
        {
            var p = new PrinterDeleteTasktriggerParameter();
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterDeleteTasktriggerParameter();
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync(PrinterDeleteTasktriggerParameter parameter)
        {
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync(PrinterDeleteTasktriggerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(parameter, cancellationToken);
        }
    }
}
