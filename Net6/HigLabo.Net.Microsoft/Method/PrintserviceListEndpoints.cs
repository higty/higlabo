using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintserviceListEndpointsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Services_PrintServiceId_Endpoints,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Services_PrintServiceId_Endpoints: return $"/print/services/{PrintServiceId}/endpoints";
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
        public string PrintServiceId { get; set; }
    }
    public partial class PrintserviceListEndpointsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/printserviceendpoint?view=graph-rest-1.0
        /// </summary>
        public partial class PrintServiceEndpoint
        {
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? Uri { get; set; }
        }

        public PrintServiceEndpoint[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync()
        {
            var p = new PrintserviceListEndpointsParameter();
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintserviceListEndpointsParameter();
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync(PrintserviceListEndpointsParameter parameter)
        {
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync(PrintserviceListEndpointsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(parameter, cancellationToken);
        }
    }
}
