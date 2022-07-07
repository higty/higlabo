using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterListTasktriggersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string PrinterId { get; set; }
    }
    public partial class PrinterListTasktriggersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printtasktrigger?view=graph-rest-1.0
        /// </summary>
        public partial class PrintTaskTrigger
        {
            public string? Id { get; set; }
            public PrintEvent? Event { get; set; }
        }

        public PrintTaskTrigger[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListTasktriggersResponse> PrinterListTasktriggersAsync()
        {
            var p = new PrinterListTasktriggersParameter();
            return await this.SendAsync<PrinterListTasktriggersParameter, PrinterListTasktriggersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListTasktriggersResponse> PrinterListTasktriggersAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterListTasktriggersParameter();
            return await this.SendAsync<PrinterListTasktriggersParameter, PrinterListTasktriggersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListTasktriggersResponse> PrinterListTasktriggersAsync(PrinterListTasktriggersParameter parameter)
        {
            return await this.SendAsync<PrinterListTasktriggersParameter, PrinterListTasktriggersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-tasktriggers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListTasktriggersResponse> PrinterListTasktriggersAsync(PrinterListTasktriggersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterListTasktriggersParameter, PrinterListTasktriggersResponse>(parameter, cancellationToken);
        }
    }
}
