using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
    /// </summary>
    public partial class PrintserviceListEndpointsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrintServiceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Services_PrintServiceId_Endpoints: return $"/print/services/{PrintServiceId}/endpoints";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            Uri,
        }
        public enum ApiPath
        {
            Print_Services_PrintServiceId_Endpoints,
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
    public partial class PrintserviceListEndpointsResponse : RestApiResponse
    {
        public PrintServiceEndpoint[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync()
        {
            var p = new PrintserviceListEndpointsParameter();
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintserviceListEndpointsParameter();
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync(PrintserviceListEndpointsParameter parameter)
        {
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-list-endpoints?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceListEndpointsResponse> PrintserviceListEndpointsAsync(PrintserviceListEndpointsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintserviceListEndpointsParameter, PrintserviceListEndpointsResponse>(parameter, cancellationToken);
        }
    }
}
