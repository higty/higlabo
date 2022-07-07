using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintershareDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Shares_PrinterShareId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares_PrinterShareId: return $"/print/shares/{PrinterShareId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PrinterShareId { get; set; }
    }
    public partial class PrintershareDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteResponse> PrintershareDeleteAsync()
        {
            var p = new PrintershareDeleteParameter();
            return await this.SendAsync<PrintershareDeleteParameter, PrintershareDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteResponse> PrintershareDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareDeleteParameter();
            return await this.SendAsync<PrintershareDeleteParameter, PrintershareDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteResponse> PrintershareDeleteAsync(PrintershareDeleteParameter parameter)
        {
            return await this.SendAsync<PrintershareDeleteParameter, PrintershareDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteResponse> PrintershareDeleteAsync(PrintershareDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareDeleteParameter, PrintershareDeleteResponse>(parameter, cancellationToken);
        }
    }
}
