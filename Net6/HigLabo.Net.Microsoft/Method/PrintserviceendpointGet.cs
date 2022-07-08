using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintserviceendpointGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrintServiceId { get; set; }
            public string PrintServiceEndpointId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Services_PrintServiceId_Endpoints_PrintServiceEndpointId: return $"/print/services/{PrintServiceId}/endpoints/{PrintServiceEndpointId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Services_PrintServiceId_Endpoints_PrintServiceEndpointId,
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
    public partial class PrintserviceendpointGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Uri { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceendpointGetResponse> PrintserviceendpointGetAsync()
        {
            var p = new PrintserviceendpointGetParameter();
            return await this.SendAsync<PrintserviceendpointGetParameter, PrintserviceendpointGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceendpointGetResponse> PrintserviceendpointGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintserviceendpointGetParameter();
            return await this.SendAsync<PrintserviceendpointGetParameter, PrintserviceendpointGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceendpointGetResponse> PrintserviceendpointGetAsync(PrintserviceendpointGetParameter parameter)
        {
            return await this.SendAsync<PrintserviceendpointGetParameter, PrintserviceendpointGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceendpointGetResponse> PrintserviceendpointGetAsync(PrintserviceendpointGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintserviceendpointGetParameter, PrintserviceendpointGetResponse>(parameter, cancellationToken);
        }
    }
}
