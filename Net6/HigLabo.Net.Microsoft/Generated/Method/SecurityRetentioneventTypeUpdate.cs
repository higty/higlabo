using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-update?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventTypeUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
    public partial class SecurityRetentioneventTypeUpdateResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypeUpdateResponse> SecurityRetentioneventTypeUpdateAsync()
        {
            var p = new SecurityRetentioneventTypeUpdateParameter();
            return await this.SendAsync<SecurityRetentioneventTypeUpdateParameter, SecurityRetentioneventTypeUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypeUpdateResponse> SecurityRetentioneventTypeUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventTypeUpdateParameter();
            return await this.SendAsync<SecurityRetentioneventTypeUpdateParameter, SecurityRetentioneventTypeUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypeUpdateResponse> SecurityRetentioneventTypeUpdateAsync(SecurityRetentioneventTypeUpdateParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventTypeUpdateParameter, SecurityRetentioneventTypeUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityRetentioneventTypeUpdateResponse> SecurityRetentioneventTypeUpdateAsync(SecurityRetentioneventTypeUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventTypeUpdateParameter, SecurityRetentioneventTypeUpdateResponse>(parameter, cancellationToken);
        }
    }
}
