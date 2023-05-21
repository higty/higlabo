using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
    /// </summary>
    public partial class PrintListSharesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares: return $"/print/shares";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AllowAllUsers,
            Capabilities,
            CreatedDateTime,
            Defaults,
            DisplayName,
            Id,
            IsAcceptingJobs,
            Location,
            Manufacturer,
            Model,
            Status,
            Printer,
            AllowedUsers,
            AllowedGroups,
            Jobs,
        }
        public enum ApiPath
        {
            Print_Shares,
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
    public partial class PrintListSharesResponse : RestApiResponse
    {
        public PrinterShare[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync()
        {
            var p = new PrintListSharesParameter();
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListSharesParameter();
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync(PrintListSharesParameter parameter)
        {
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync(PrintListSharesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(parameter, cancellationToken);
        }
    }
}
