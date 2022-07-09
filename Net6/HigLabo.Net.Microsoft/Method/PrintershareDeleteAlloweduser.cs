using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintershareDeleteAllowedUserParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedUsers_UserId_ref: return $"/print/shares/{PrinterShareId}/allowedUsers/{UserId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedUsers_UserId_ref,
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
    public partial class PrintershareDeleteAllowedUserResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedUserResponse> PrintershareDeleteAllowedUserAsync()
        {
            var p = new PrintershareDeleteAllowedUserParameter();
            return await this.SendAsync<PrintershareDeleteAllowedUserParameter, PrintershareDeleteAllowedUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedUserResponse> PrintershareDeleteAllowedUserAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareDeleteAllowedUserParameter();
            return await this.SendAsync<PrintershareDeleteAllowedUserParameter, PrintershareDeleteAllowedUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedUserResponse> PrintershareDeleteAllowedUserAsync(PrintershareDeleteAllowedUserParameter parameter)
        {
            return await this.SendAsync<PrintershareDeleteAllowedUserParameter, PrintershareDeleteAllowedUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-delete-alloweduser?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareDeleteAllowedUserResponse> PrintershareDeleteAllowedUserAsync(PrintershareDeleteAllowedUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareDeleteAllowedUserParameter, PrintershareDeleteAllowedUserResponse>(parameter, cancellationToken);
        }
    }
}
