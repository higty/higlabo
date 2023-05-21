using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public partial class PrintersharePostAllowedGroupsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_Shares_PrinterShareId_AllowedGroups_ref: return $"/print/printers/{PrinterId}/shares/{PrinterShareId}/allowedGroups/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Printers_PrinterId_Shares_PrinterShareId_AllowedGroups_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class PrintersharePostAllowedGroupsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedGroupsResponse> PrintersharePostAllowedGroupsAsync()
        {
            var p = new PrintersharePostAllowedGroupsParameter();
            return await this.SendAsync<PrintersharePostAllowedGroupsParameter, PrintersharePostAllowedGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedGroupsResponse> PrintersharePostAllowedGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintersharePostAllowedGroupsParameter();
            return await this.SendAsync<PrintersharePostAllowedGroupsParameter, PrintersharePostAllowedGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedGroupsResponse> PrintersharePostAllowedGroupsAsync(PrintersharePostAllowedGroupsParameter parameter)
        {
            return await this.SendAsync<PrintersharePostAllowedGroupsParameter, PrintersharePostAllowedGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-post-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedGroupsResponse> PrintersharePostAllowedGroupsAsync(PrintersharePostAllowedGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintersharePostAllowedGroupsParameter, PrintersharePostAllowedGroupsResponse>(parameter, cancellationToken);
        }
    }
}
