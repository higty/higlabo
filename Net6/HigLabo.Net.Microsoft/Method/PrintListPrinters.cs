using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintListPrintersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers: return $"/print/printers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            DisplayName,
            Manufacturer,
            Model,
            RegisteredDateTime,
            Status,
            IsShared,
            HasPhysicalDevice,
            IsAcceptingJobs,
            Location,
            Defaults,
            Capabilities,
            LastSeenDateTime,
            Jobs,
            Shares,
            Connectors,
            TaskTriggers,
        }
        public enum ApiPath
        {
            Print_Printers,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class PrintListPrintersResponse : RestApiResponse
    {
        public Printer[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync()
        {
            var p = new PrintListPrintersParameter();
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListPrintersParameter();
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter)
        {
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, cancellationToken);
        }
    }
}
