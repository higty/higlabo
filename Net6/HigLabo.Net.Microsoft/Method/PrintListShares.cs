using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintListSharesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Shares,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares: return $"/print/shares";
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
    }
    public partial class PrintListSharesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printershare?view=graph-rest-1.0
        /// </summary>
        public partial class PrinterShare
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Manufacturer { get; set; }
            public string? Model { get; set; }
            public bool? IsAcceptingJobs { get; set; }
            public PrinterDefaults? Defaults { get; set; }
            public PrinterCapabilities? Capabilities { get; set; }
            public PrinterLocation? Location { get; set; }
            public PrinterStatus? Status { get; set; }
            public bool? AllowAllUsers { get; set; }
        }

        public PrinterShare[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync()
        {
            var p = new PrintListSharesParameter();
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListSharesParameter();
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync(PrintListSharesParameter parameter)
        {
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListSharesResponse> PrintListSharesAsync(PrintListSharesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(parameter, cancellationToken);
        }
    }
}
