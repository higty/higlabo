using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintersharePostAllowedgroupsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_PrinterId_Shares_PrinterShareId_AllowedGroups_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Shares_PrinterShareId_AllowedGroups_ref: return $"/print/printers/{PrinterId}/shares/{PrinterShareId}/allowedGroups/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string PrinterId { get; set; }
        public string PrinterShareId { get; set; }
    }
    public partial class PrintersharePostAllowedgroupsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedgroupsResponse> PrintersharePostAllowedgroupsAsync()
        {
            var p = new PrintersharePostAllowedgroupsParameter();
            return await this.SendAsync<PrintersharePostAllowedgroupsParameter, PrintersharePostAllowedgroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedgroupsResponse> PrintersharePostAllowedgroupsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintersharePostAllowedgroupsParameter();
            return await this.SendAsync<PrintersharePostAllowedgroupsParameter, PrintersharePostAllowedgroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedgroupsResponse> PrintersharePostAllowedgroupsAsync(PrintersharePostAllowedgroupsParameter parameter)
        {
            return await this.SendAsync<PrintersharePostAllowedgroupsParameter, PrintersharePostAllowedgroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedgroupsResponse> PrintersharePostAllowedgroupsAsync(PrintersharePostAllowedgroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintersharePostAllowedgroupsParameter, PrintersharePostAllowedgroupsResponse>(parameter, cancellationToken);
        }
    }
}
