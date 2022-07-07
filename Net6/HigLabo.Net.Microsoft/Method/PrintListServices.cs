using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintListServicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Services,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Services: return $"/print/services";
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
    public partial class PrintListServicesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printservice?view=graph-rest-1.0
        /// </summary>
        public partial class PrintService
        {
            public string? Id { get; set; }
        }

        public PrintService[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListServicesResponse> PrintListServicesAsync()
        {
            var p = new PrintListServicesParameter();
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListServicesResponse> PrintListServicesAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListServicesParameter();
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListServicesResponse> PrintListServicesAsync(PrintListServicesParameter parameter)
        {
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListServicesResponse> PrintListServicesAsync(PrintListServicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(parameter, cancellationToken);
        }
    }
}
