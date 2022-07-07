using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintershareDeleteAlloweduserParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedUsers_UserId_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedUsers_UserId_ref: return $"/print/shares/{PrinterShareId}/allowedUsers/{UserId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PrinterShareId { get; set; }
        public string UserId { get; set; }
    }
    public partial class PrintershareDeleteAlloweduserResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAlloweduserResponse> PrintershareDeleteAlloweduserAsync()
        {
            var p = new PrintershareDeleteAlloweduserParameter();
            return await this.SendAsync<PrintershareDeleteAlloweduserParameter, PrintershareDeleteAlloweduserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAlloweduserResponse> PrintershareDeleteAlloweduserAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareDeleteAlloweduserParameter();
            return await this.SendAsync<PrintershareDeleteAlloweduserParameter, PrintershareDeleteAlloweduserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAlloweduserResponse> PrintershareDeleteAlloweduserAsync(PrintershareDeleteAlloweduserParameter parameter)
        {
            return await this.SendAsync<PrintershareDeleteAlloweduserParameter, PrintershareDeleteAlloweduserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAlloweduserResponse> PrintershareDeleteAlloweduserAsync(PrintershareDeleteAlloweduserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareDeleteAlloweduserParameter, PrintershareDeleteAlloweduserResponse>(parameter, cancellationToken);
        }
    }
}
