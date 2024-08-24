using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
    /// </summary>
    public partial class PrintServiceendpointGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrintServiceId { get; set; }
            public string? PrintServiceEndpointId { get; set; }

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
    public partial class PrintServiceendpointGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? Uri { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceendpointGetResponse> PrintServiceendpointGetAsync()
        {
            var p = new PrintServiceendpointGetParameter();
            return await this.SendAsync<PrintServiceendpointGetParameter, PrintServiceendpointGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceendpointGetResponse> PrintServiceendpointGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintServiceendpointGetParameter();
            return await this.SendAsync<PrintServiceendpointGetParameter, PrintServiceendpointGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceendpointGetResponse> PrintServiceendpointGetAsync(PrintServiceendpointGetParameter parameter)
        {
            return await this.SendAsync<PrintServiceendpointGetParameter, PrintServiceendpointGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printserviceendpoint-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceendpointGetResponse> PrintServiceendpointGetAsync(PrintServiceendpointGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintServiceendpointGetParameter, PrintServiceendpointGetResponse>(parameter, cancellationToken);
        }
    }
}
