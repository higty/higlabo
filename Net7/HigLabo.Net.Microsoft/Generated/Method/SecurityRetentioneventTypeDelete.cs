using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-delete?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventTypeDeleteParameter : IRestApiParameter
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
                    case ApiPath.Security_Labels_RetentionLabels_RetentionLabelId_EventType_ref: return $"/security/labels/retentionLabels/{RetentionLabelId}/eventType/$ref";
                    case ApiPath.Security_TriggerTypes_RetentionEventTypes_RetentionEventTypeId_ref: return $"/security/triggerTypes/retentionEventTypes/{RetentionEventTypeId}/$ref";
                    case ApiPath.Security_Triggers_RetentionEvents_RetentionEventId_RetentionEventType_ref: return $"/security/triggers/retentionEvents/{RetentionEventId}/retentionEventType/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Labels_RetentionLabels_RetentionLabelId_EventType_ref,
            Security_TriggerTypes_RetentionEventTypes_RetentionEventTypeId_ref,
            Security_Triggers_RetentionEvents_RetentionEventId_RetentionEventType_ref,
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
    public partial class SecurityRetentioneventTypeDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeDeleteResponse> SecurityRetentioneventTypeDeleteAsync()
        {
            var p = new SecurityRetentioneventTypeDeleteParameter();
            return await this.SendAsync<SecurityRetentioneventTypeDeleteParameter, SecurityRetentioneventTypeDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeDeleteResponse> SecurityRetentioneventTypeDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventTypeDeleteParameter();
            return await this.SendAsync<SecurityRetentioneventTypeDeleteParameter, SecurityRetentioneventTypeDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeDeleteResponse> SecurityRetentioneventTypeDeleteAsync(SecurityRetentioneventTypeDeleteParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventTypeDeleteParameter, SecurityRetentioneventTypeDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeDeleteResponse> SecurityRetentioneventTypeDeleteAsync(SecurityRetentioneventTypeDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventTypeDeleteParameter, SecurityRetentioneventTypeDeleteResponse>(parameter, cancellationToken);
        }
    }
}
