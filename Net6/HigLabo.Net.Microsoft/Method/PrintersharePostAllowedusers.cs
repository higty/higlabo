using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintersharePostAllowedusersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedUsers_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedUsers_ref: return $"/print/shares/{PrinterShareId}/allowedUsers/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterShareId { get; set; }
    }
    public partial class PrintersharePostAllowedusersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedusersResponse> PrintersharePostAllowedusersAsync()
        {
            var p = new PrintersharePostAllowedusersParameter();
            return await this.SendAsync<PrintersharePostAllowedusersParameter, PrintersharePostAllowedusersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedusersResponse> PrintersharePostAllowedusersAsync(CancellationToken cancellationToken)
        {
            var p = new PrintersharePostAllowedusersParameter();
            return await this.SendAsync<PrintersharePostAllowedusersParameter, PrintersharePostAllowedusersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedusersResponse> PrintersharePostAllowedusersAsync(PrintersharePostAllowedusersParameter parameter)
        {
            return await this.SendAsync<PrintersharePostAllowedusersParameter, PrintersharePostAllowedusersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedusersResponse> PrintersharePostAllowedusersAsync(PrintersharePostAllowedusersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintersharePostAllowedusersParameter, PrintersharePostAllowedusersResponse>(parameter, cancellationToken);
        }
    }
}
