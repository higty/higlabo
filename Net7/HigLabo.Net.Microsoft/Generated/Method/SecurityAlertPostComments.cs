using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-alert-post-comments?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityAlertPostCommentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AlertId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Alerts_v2_AlertId_Comments: return $"/security/alerts_v2/{AlertId}/comments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Alerts_v2_AlertId_Comments,
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
        public string? Comment { get; set; }
        public string? CreatedByDisplayName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
    public partial class SecurityAlertPostCommentsResponse : RestApiResponse
    {
        public string? Comment { get; set; }
        public string? CreatedByDisplayName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-alert-post-comments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-alert-post-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityAlertPostCommentsResponse> SecurityAlertPostCommentsAsync()
        {
            var p = new SecurityAlertPostCommentsParameter();
            return await this.SendAsync<SecurityAlertPostCommentsParameter, SecurityAlertPostCommentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-alert-post-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityAlertPostCommentsResponse> SecurityAlertPostCommentsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityAlertPostCommentsParameter();
            return await this.SendAsync<SecurityAlertPostCommentsParameter, SecurityAlertPostCommentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-alert-post-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityAlertPostCommentsResponse> SecurityAlertPostCommentsAsync(SecurityAlertPostCommentsParameter parameter)
        {
            return await this.SendAsync<SecurityAlertPostCommentsParameter, SecurityAlertPostCommentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-alert-post-comments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityAlertPostCommentsResponse> SecurityAlertPostCommentsAsync(SecurityAlertPostCommentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityAlertPostCommentsParameter, SecurityAlertPostCommentsResponse>(parameter, cancellationToken);
        }
    }
}
