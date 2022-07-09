using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintersharePostAllowedUsersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedUsers_ref: return $"/print/shares/{PrinterShareId}/allowedUsers/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedUsers_ref,
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
    public partial class PrintersharePostAllowedUsersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedUsersResponse> PrintersharePostAllowedUsersAsync()
        {
            var p = new PrintersharePostAllowedUsersParameter();
            return await this.SendAsync<PrintersharePostAllowedUsersParameter, PrintersharePostAllowedUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedUsersResponse> PrintersharePostAllowedUsersAsync(CancellationToken cancellationToken)
        {
            var p = new PrintersharePostAllowedUsersParameter();
            return await this.SendAsync<PrintersharePostAllowedUsersParameter, PrintersharePostAllowedUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedUsersResponse> PrintersharePostAllowedUsersAsync(PrintersharePostAllowedUsersParameter parameter)
        {
            return await this.SendAsync<PrintersharePostAllowedUsersParameter, PrintersharePostAllowedUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printershare-post-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintersharePostAllowedUsersResponse> PrintersharePostAllowedUsersAsync(PrintersharePostAllowedUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintersharePostAllowedUsersParameter, PrintersharePostAllowedUsersResponse>(parameter, cancellationToken);
        }
    }
}
