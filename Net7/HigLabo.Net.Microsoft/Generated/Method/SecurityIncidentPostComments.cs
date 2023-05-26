using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-incident-post-comments?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityIncidentPostCommentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IncidentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Incidents_IncidentId_Comments: return $"/security/incidents/{IncidentId}/comments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Incidents_IncidentId_Comments,
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
    public partial class SecurityIncidentPostCommentsResponse : RestApiResponse
    {
        public string? Comment { get; set; }
        public string? CreatedByDisplayName { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-incident-post-comments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-incident-post-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityIncidentPostCommentsResponse> SecurityIncidentPostCommentsAsync()
        {
            var p = new SecurityIncidentPostCommentsParameter();
            return await this.SendAsync<SecurityIncidentPostCommentsParameter, SecurityIncidentPostCommentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-incident-post-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityIncidentPostCommentsResponse> SecurityIncidentPostCommentsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityIncidentPostCommentsParameter();
            return await this.SendAsync<SecurityIncidentPostCommentsParameter, SecurityIncidentPostCommentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-incident-post-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityIncidentPostCommentsResponse> SecurityIncidentPostCommentsAsync(SecurityIncidentPostCommentsParameter parameter)
        {
            return await this.SendAsync<SecurityIncidentPostCommentsParameter, SecurityIncidentPostCommentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-incident-post-comments?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityIncidentPostCommentsResponse> SecurityIncidentPostCommentsAsync(SecurityIncidentPostCommentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityIncidentPostCommentsParameter, SecurityIncidentPostCommentsResponse>(parameter, cancellationToken);
        }
    }
}
