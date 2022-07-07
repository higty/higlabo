using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintconnectorDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Connectors_PrintConnectorId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Connectors_PrintConnectorId: return $"/print/connectors/{PrintConnectorId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PrintConnectorId { get; set; }
    }
    public partial class PrintconnectorDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorDeleteResponse> PrintconnectorDeleteAsync()
        {
            var p = new PrintconnectorDeleteParameter();
            return await this.SendAsync<PrintconnectorDeleteParameter, PrintconnectorDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorDeleteResponse> PrintconnectorDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PrintconnectorDeleteParameter();
            return await this.SendAsync<PrintconnectorDeleteParameter, PrintconnectorDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorDeleteResponse> PrintconnectorDeleteAsync(PrintconnectorDeleteParameter parameter)
        {
            return await this.SendAsync<PrintconnectorDeleteParameter, PrintconnectorDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintconnectorDeleteResponse> PrintconnectorDeleteAsync(PrintconnectorDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintconnectorDeleteParameter, PrintconnectorDeleteResponse>(parameter, cancellationToken);
        }
    }
}
