using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinterListSharesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_Shares: return $"/print/printers/{PrinterId}/shares";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            DisplayName,
            CreatedDateTime,
            Manufacturer,
            Model,
            IsAcceptingJobs,
            Defaults,
            Capabilities,
            Location,
            Status,
            AllowAllUsers,
            Printer,
            AllowedUsers,
            AllowedGroups,
            Jobs,
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Shares,
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
    public partial class PrinterListSharesResponse : RestApiResponse
    {
        public PrinterShare[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync()
        {
            var p = new PrinterListSharesParameter();
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterListSharesParameter();
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync(PrinterListSharesParameter parameter)
        {
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinterListSharesResponse> PrinterListSharesAsync(PrinterListSharesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(parameter, cancellationToken);
        }
    }
}
