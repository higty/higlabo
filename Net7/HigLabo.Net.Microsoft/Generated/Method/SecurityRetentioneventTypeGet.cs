using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventTypeGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RetentionLabelId { get; set; }
            public string? RetentionEventTypeId { get; set; }
            public string? RetentionEventId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Labels_RetentionLabels_RetentionLabelId_EventType: return $"/security/labels/retentionLabels/{RetentionLabelId}/eventType";
                    case ApiPath.Security_TriggerTypes_RetentionEventTypes_RetentionEventTypeId: return $"/security/triggerTypes/retentionEventTypes/{RetentionEventTypeId}";
                    case ApiPath.Security_Triggers_RetentionEvents_RetentionEventId_RetentionEventType: return $"/security/triggers/retentionEvents/{RetentionEventId}/retentionEventType";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Labels_RetentionLabels_RetentionLabelId_EventType,
            Security_TriggerTypes_RetentionEventTypes_RetentionEventTypeId,
            Security_Triggers_RetentionEvents_RetentionEventId_RetentionEventType,
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
    public partial class SecurityRetentioneventTypeGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeGetResponse> SecurityRetentioneventTypeGetAsync()
        {
            var p = new SecurityRetentioneventTypeGetParameter();
            return await this.SendAsync<SecurityRetentioneventTypeGetParameter, SecurityRetentioneventTypeGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeGetResponse> SecurityRetentioneventTypeGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventTypeGetParameter();
            return await this.SendAsync<SecurityRetentioneventTypeGetParameter, SecurityRetentioneventTypeGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeGetResponse> SecurityRetentioneventTypeGetAsync(SecurityRetentioneventTypeGetParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventTypeGetParameter, SecurityRetentioneventTypeGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeGetResponse> SecurityRetentioneventTypeGetAsync(SecurityRetentioneventTypeGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventTypeGetParameter, SecurityRetentioneventTypeGetResponse>(parameter, cancellationToken);
        }
    }
}
