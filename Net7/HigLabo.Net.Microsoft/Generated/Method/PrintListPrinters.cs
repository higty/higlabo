using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
    /// </summary>
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
            Capabilities,
            Defaults,
            DisplayName,
            HasPhysicalDevice,
            Id,
            IsAcceptingJobs,
            IsShared,
            LastSeenDateTime,
            Location,
            Manufacturer,
            Model,
            RegisteredDateTime,
            Status,
            Connectors,
            Jobs,
            Shares,
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
        public Printer[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync()
        {
            var p = new PrintListPrintersParameter();
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListPrintersParameter();
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter)
        {
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, cancellationToken);
        }
    }
}
