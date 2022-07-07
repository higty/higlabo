using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintershareDeleteAllowedgroupParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedGroups_GroupId_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedGroups_GroupId_ref: return $"/print/shares/{PrinterShareId}/allowedGroups/{GroupId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string PrinterShareId { get; set; }
        public string GroupId { get; set; }
    }
    public partial class PrintershareDeleteAllowedgroupResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedgroupResponse> PrintershareDeleteAllowedgroupAsync()
        {
            var p = new PrintershareDeleteAllowedgroupParameter();
            return await this.SendAsync<PrintershareDeleteAllowedgroupParameter, PrintershareDeleteAllowedgroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedgroupResponse> PrintershareDeleteAllowedgroupAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareDeleteAllowedgroupParameter();
            return await this.SendAsync<PrintershareDeleteAllowedgroupParameter, PrintershareDeleteAllowedgroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedgroupResponse> PrintershareDeleteAllowedgroupAsync(PrintershareDeleteAllowedgroupParameter parameter)
        {
            return await this.SendAsync<PrintershareDeleteAllowedgroupParameter, PrintershareDeleteAllowedgroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedgroupResponse> PrintershareDeleteAllowedgroupAsync(PrintershareDeleteAllowedgroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareDeleteAllowedgroupParameter, PrintershareDeleteAllowedgroupResponse>(parameter, cancellationToken);
        }
    }
}
