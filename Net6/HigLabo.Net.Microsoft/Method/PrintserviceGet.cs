using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintserviceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Services_PrintServiceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Services_PrintServiceId: return $"/print/services/{PrintServiceId}";
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
    public partial class PrintserviceGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceGetResponse> PrintserviceGetAsync()
        {
            var p = new PrintserviceGetParameter();
            return await this.SendAsync<PrintserviceGetParameter, PrintserviceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceGetResponse> PrintserviceGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintserviceGetParameter();
            return await this.SendAsync<PrintserviceGetParameter, PrintserviceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceGetResponse> PrintserviceGetAsync(PrintserviceGetParameter parameter)
        {
            return await this.SendAsync<PrintserviceGetParameter, PrintserviceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printservice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintserviceGetResponse> PrintserviceGetAsync(PrintserviceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintserviceGetParameter, PrintserviceGetResponse>(parameter, cancellationToken);
        }
    }
}
