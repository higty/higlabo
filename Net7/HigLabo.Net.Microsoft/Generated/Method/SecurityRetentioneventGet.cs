using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RetentionEventId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Triggers_RetentionEvents_RetentionEventId: return $"/security/triggers/retentionEvents/{RetentionEventId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Triggers_RetentionEvents_RetentionEventId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class SecurityRetentioneventGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventGetResponse> SecurityRetentioneventGetAsync()
        {
            var p = new SecurityRetentioneventGetParameter();
            return await this.SendAsync<SecurityRetentioneventGetParameter, SecurityRetentioneventGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventGetResponse> SecurityRetentioneventGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventGetParameter();
            return await this.SendAsync<SecurityRetentioneventGetParameter, SecurityRetentioneventGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventGetResponse> SecurityRetentioneventGetAsync(SecurityRetentioneventGetParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventGetParameter, SecurityRetentioneventGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventGetResponse> SecurityRetentioneventGetAsync(SecurityRetentioneventGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventGetParameter, SecurityRetentioneventGetResponse>(parameter, cancellationToken);
        }
    }
}
