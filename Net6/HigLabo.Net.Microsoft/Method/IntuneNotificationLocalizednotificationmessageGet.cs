using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationLocalizednotificationmessageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string NotificationMessageTemplateId { get; set; }
        public string LocalizedNotificationMessageId { get; set; }
    }
    public partial class IntuneNotificationLocalizednotificationmessageGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageGetResponse> IntuneNotificationLocalizednotificationmessageGetAsync()
        {
            var p = new IntuneNotificationLocalizednotificationmessageGetParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageGetParameter, IntuneNotificationLocalizednotificationmessageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageGetResponse> IntuneNotificationLocalizednotificationmessageGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationLocalizednotificationmessageGetParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageGetParameter, IntuneNotificationLocalizednotificationmessageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageGetResponse> IntuneNotificationLocalizednotificationmessageGetAsync(IntuneNotificationLocalizednotificationmessageGetParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageGetParameter, IntuneNotificationLocalizednotificationmessageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageGetResponse> IntuneNotificationLocalizednotificationmessageGetAsync(IntuneNotificationLocalizednotificationmessageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageGetParameter, IntuneNotificationLocalizednotificationmessageGetResponse>(parameter, cancellationToken);
        }
    }
}
