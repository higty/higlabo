using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterPostTasktriggersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrinterId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_TaskTriggers: return $"/print/printers/{PrinterId}/taskTriggers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId_TaskTriggers,
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
        public string? Id { get; set; }
        public PrintEvent? Event { get; set; }
        public PrintTaskDefinition? Definition { get; set; }
    }
    public partial class PrinterPostTasktriggersResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PrintEvent? Event { get; set; }
        public PrintTaskDefinition? Definition { get; set; }
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
