using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
    /// </summary>
    public partial class PrintServiceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrintServiceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Services_PrintServiceId: return $"/print/services/{PrintServiceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Services_PrintServiceId,
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
    public partial class PrintServiceGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PrintServiceEndpoint[]? Endpoints { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceGetResponse> PrintServiceGetAsync()
        {
            var p = new PrintServiceGetParameter();
            return await this.SendAsync<PrintServiceGetParameter, PrintServiceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceGetResponse> PrintServiceGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintServiceGetParameter();
            return await this.SendAsync<PrintServiceGetParameter, PrintServiceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceGetResponse> PrintServiceGetAsync(PrintServiceGetParameter parameter)
        {
            return await this.SendAsync<PrintServiceGetParameter, PrintServiceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintServiceGetResponse> PrintServiceGetAsync(PrintServiceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintServiceGetParameter, PrintServiceGetResponse>(parameter, cancellationToken);
        }
    }
}
