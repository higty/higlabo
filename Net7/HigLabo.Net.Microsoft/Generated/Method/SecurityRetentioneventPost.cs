using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-post?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Triggers_RetentionEvents: return $"/security/triggers/retentionEvents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Triggers_RetentionEvents,
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
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public EventQuery[]? EventQuery { get; set; }
        public DateTimeOffset? EventTriggerDateTime { get; set; }
        public string? RetentionEventType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public EventPropagationResult? EventPropagationResult { get; set; }
        public EventQuery[]? EventQueries { get; set; }
        public RetentionEventStatus[]? RetentionEventStatus { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LastStatusUpdateDateTime { get; set; }
    }
    public partial class SecurityRetentioneventPostResponse : RestApiResponse
    {
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public EventPropagationResult? EventPropagationResult { get; set; }
        public EventQuery[]? EventQueries { get; set; }
        public RetentionEventStatus[]? RetentionEventStatus { get; set; }
        public DateTimeOffset? EventTriggerDateTime { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LastStatusUpdateDateTime { get; set; }
        public RetentionEventType? RetentionEventType { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventPostResponse> SecurityRetentioneventPostAsync()
        {
            var p = new SecurityRetentioneventPostParameter();
            return await this.SendAsync<SecurityRetentioneventPostParameter, SecurityRetentioneventPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventPostResponse> SecurityRetentioneventPostAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventPostParameter();
            return await this.SendAsync<SecurityRetentioneventPostParameter, SecurityRetentioneventPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventPostResponse> SecurityRetentioneventPostAsync(SecurityRetentioneventPostParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventPostParameter, SecurityRetentioneventPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventPostResponse> SecurityRetentioneventPostAsync(SecurityRetentioneventPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventPostParameter, SecurityRetentioneventPostResponse>(parameter, cancellationToken);
        }
    }
}
