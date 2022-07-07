using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationLocalizednotificationmessageDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_LocalizedNotificationMessages_LocalizedNotificationMessageId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_LocalizedNotificationMessages_LocalizedNotificationMessageId: return $"/deviceManagement/notificationMessageTemplates/{NotificationMessageTemplateId}/localizedNotificationMessages/{LocalizedNotificationMessageId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string NotificationMessageTemplateId { get; set; }
        public string LocalizedNotificationMessageId { get; set; }
    }
    public partial class IntuneNotificationLocalizednotificationmessageDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageDeleteResponse> IntuneNotificationLocalizednotificationmessageDeleteAsync()
        {
            var p = new IntuneNotificationLocalizednotificationmessageDeleteParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageDeleteParameter, IntuneNotificationLocalizednotificationmessageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageDeleteResponse> IntuneNotificationLocalizednotificationmessageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationLocalizednotificationmessageDeleteParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageDeleteParameter, IntuneNotificationLocalizednotificationmessageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageDeleteResponse> IntuneNotificationLocalizednotificationmessageDeleteAsync(IntuneNotificationLocalizednotificationmessageDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageDeleteParameter, IntuneNotificationLocalizednotificationmessageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageDeleteResponse> IntuneNotificationLocalizednotificationmessageDeleteAsync(IntuneNotificationLocalizednotificationmessageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageDeleteParameter, IntuneNotificationLocalizednotificationmessageDeleteResponse>(parameter, cancellationToken);
        }
    }
}
