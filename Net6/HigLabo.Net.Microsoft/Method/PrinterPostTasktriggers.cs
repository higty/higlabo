using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterPostTasktriggersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_TaskTriggers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_TaskTriggers: return $"/print/printers/{PrinterId}/taskTriggers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterId { get; set; }
    }
    public partial class PrinterPostTasktriggersResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PrintEvent? Event { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostTasktriggersResponse> PrinterPostTasktriggersAsync()
        {
            var p = new PrinterPostTasktriggersParameter();
            return await this.SendAsync<PrinterPostTasktriggersParameter, PrinterPostTasktriggersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostTasktriggersResponse> PrinterPostTasktriggersAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterPostTasktriggersParameter();
            return await this.SendAsync<PrinterPostTasktriggersParameter, PrinterPostTasktriggersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostTasktriggersResponse> PrinterPostTasktriggersAsync(PrinterPostTasktriggersParameter parameter)
        {
            return await this.SendAsync<PrinterPostTasktriggersParameter, PrinterPostTasktriggersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-post-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterPostTasktriggersResponse> PrinterPostTasktriggersAsync(PrinterPostTasktriggersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterPostTasktriggersParameter, PrinterPostTasktriggersResponse>(parameter, cancellationToken);
        }
    }
}
