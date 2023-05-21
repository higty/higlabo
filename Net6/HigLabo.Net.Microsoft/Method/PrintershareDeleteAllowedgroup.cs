using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
    /// </summary>
    public partial class PrintershareDeleteAllowedGroupParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }
            public string? GroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedGroups_GroupId_ref: return $"/print/shares/{PrinterShareId}/allowedGroups/{GroupId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedGroups_GroupId_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class PrintershareDeleteAllowedGroupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedGroupResponse> PrintershareDeleteAllowedGroupAsync()
        {
            var p = new PrintershareDeleteAllowedGroupParameter();
            return await this.SendAsync<PrintershareDeleteAllowedGroupParameter, PrintershareDeleteAllowedGroupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedGroupResponse> PrintershareDeleteAllowedGroupAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareDeleteAllowedGroupParameter();
            return await this.SendAsync<PrintershareDeleteAllowedGroupParameter, PrintershareDeleteAllowedGroupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedGroupResponse> PrintershareDeleteAllowedGroupAsync(PrintershareDeleteAllowedGroupParameter parameter)
        {
            return await this.SendAsync<PrintershareDeleteAllowedGroupParameter, PrintershareDeleteAllowedGroupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-delete-allowedgroup?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedGroupResponse> PrintershareDeleteAllowedGroupAsync(PrintershareDeleteAllowedGroupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareDeleteAllowedGroupParameter, PrintershareDeleteAllowedGroupResponse>(parameter, cancellationToken);
        }
    }
}
