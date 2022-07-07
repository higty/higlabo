using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterDeleteTasktriggerParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_TaskTriggers_PrintTaskTriggerId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_TaskTriggers_PrintTaskTriggerId: return $"/print/printers/{PrinterId}/taskTriggers/{PrintTaskTriggerId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PrinterId { get; set; }
        public string PrintTaskTriggerId { get; set; }
    }
    public partial class PrinterDeleteTasktriggerResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync()
        {
            var p = new PrinterDeleteTasktriggerParameter();
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterDeleteTasktriggerParameter();
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync(PrinterDeleteTasktriggerParameter parameter)
        {
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-delete-tasktrigger?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterDeleteTasktriggerResponse> PrinterDeleteTasktriggerAsync(PrinterDeleteTasktriggerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterDeleteTasktriggerParameter, PrinterDeleteTasktriggerResponse>(parameter, cancellationToken);
        }
    }
}
