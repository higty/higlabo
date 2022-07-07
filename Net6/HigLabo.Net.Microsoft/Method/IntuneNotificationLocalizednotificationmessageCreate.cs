using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationLocalizednotificationmessageCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_LocalizedNotificationMessages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_LocalizedNotificationMessages: return $"/deviceManagement/notificationMessageTemplates/{NotificationMessageTemplateId}/localizedNotificationMessages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Locale { get; set; }
        public string? Subject { get; set; }
        public string? MessageTemplate { get; set; }
        public bool? IsDefault { get; set; }
        public string NotificationMessageTemplateId { get; set; }
    }
    public partial class IntuneNotificationLocalizednotificationmessageCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Locale { get; set; }
        public string? Subject { get; set; }
        public string? MessageTemplate { get; set; }
        public bool? IsDefault { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageCreateResponse> IntuneNotificationLocalizednotificationmessageCreateAsync()
        {
            var p = new IntuneNotificationLocalizednotificationmessageCreateParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageCreateParameter, IntuneNotificationLocalizednotificationmessageCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageCreateResponse> IntuneNotificationLocalizednotificationmessageCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationLocalizednotificationmessageCreateParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageCreateParameter, IntuneNotificationLocalizednotificationmessageCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageCreateResponse> IntuneNotificationLocalizednotificationmessageCreateAsync(IntuneNotificationLocalizednotificationmessageCreateParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageCreateParameter, IntuneNotificationLocalizednotificationmessageCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageCreateResponse> IntuneNotificationLocalizednotificationmessageCreateAsync(IntuneNotificationLocalizednotificationmessageCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageCreateParameter, IntuneNotificationLocalizednotificationmessageCreateResponse>(parameter, cancellationToken);
        }
    }
}
