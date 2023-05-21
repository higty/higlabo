using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-post?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventTypePostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_TriggerTypes_RetentionEventTypes: return $"/security/triggerTypes/retentionEventTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_TriggerTypes_RetentionEventTypes,
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
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    public partial class SecurityRetentioneventTypePostResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypePostResponse> SecurityRetentioneventTypePostAsync()
        {
            var p = new SecurityRetentioneventTypePostParameter();
            return await this.SendAsync<SecurityRetentioneventTypePostParameter, SecurityRetentioneventTypePostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypePostResponse> SecurityRetentioneventTypePostAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventTypePostParameter();
            return await this.SendAsync<SecurityRetentioneventTypePostParameter, SecurityRetentioneventTypePostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypePostResponse> SecurityRetentioneventTypePostAsync(SecurityRetentioneventTypePostParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventTypePostParameter, SecurityRetentioneventTypePostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypePostResponse> SecurityRetentioneventTypePostAsync(SecurityRetentioneventTypePostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventTypePostParameter, SecurityRetentioneventTypePostResponse>(parameter, cancellationToken);
        }
    }
}
